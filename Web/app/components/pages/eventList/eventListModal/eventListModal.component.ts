/**
 * Created by vadim.m on 11/18/2017.
 */
import { ModalDirective } from "ngx-bootstrap";
import { Component, EventEmitter, OnInit, Output, ViewChild } from "@angular/core";
import { EventListService } from "../../../../services/eventListService";
import { BaseResponse } from "../../../../objects/common/baseResponse";
import { Customer } from "../../../../objects/customer/customer";
import { ConfigService } from "../../../../services/configService";
import { ProductList } from "../../../../objects/productList/productList";
import { EventList } from "../../../../objects/eventList/eventList";

declare var $: any;

@Component({
    selector: 'event-list-modal',
    templateUrl: 'eventListModal.component.html',
    moduleId: module.id.toString()
})

export class EventListModalComponent implements OnInit {

    public eventList: EventList = new EventList();
    public eventListOrigin: EventList = new EventList();

    @Output()
    public eventListChange: EventEmitter<EventList> = new EventEmitter<EventList>();

    public isCreated: boolean = true;

    @ViewChild("eventListModal") public productListModalModal: ModalDirective;

    constructor(private eventListService: EventListService, private configService: ConfigService) {
    }

    public ngOnInit(): void {
        this.initSelect2();

        this.productListModalModal.onHidden.subscribe((x: any) => this.destroy());
    }

    public destroy(): void {
        $("#customerSelect").select2('destroy');
        $("#productListSelect").select2('destroy');
    }

    public customerSelect() {
        let self = this;

        let data = [
            {
                id: this.eventList.OwnerId,
                text: this.eventList.OwnerFullName,
                selected: true
            },
        ];

        $("#customerSelect").select2({
            width: '100%',
            data: data,
            allowClear: false,
            placeholder: '',
            ajax: {
                url: this.configService.config.apiUrl + "/customer",
                datatype: 'json',
                delay: 500,
                data: function (params: any) {
                    return {
                        query: params.term,
                        fillOrders: true,
                        // skip: 0,
                        // top: 10
                    };
                },
                processResults: function (response: BaseResponse<Array<Customer>>, params: any): any {
                    if (!response || !response.Data)
                        return [];

                    let results: any[] = response.Data.map(function (customer) {
                        return {
                            id: customer.Id,
                            text: customer.FirstName + " " + customer.LastName,
                            Item: customer
                        }
                    });

                    if (results.length == 0)
                        results.push({ id: params.term, text: params.term });

                    return {
                        results: results
                    };
                }
            },
        }).on('select2:select', function (e: any) {
            let selectedData = $(this).select2('data');

            if (!selectedData || !selectedData[0])
                return;

            self.eventList.OwnerId = selectedData[0].id;
        });

        $("#customerSelect").val(this.eventList.OwnerId).change();
    }

    public productListSelect() {

        let self = this;

        let data: [] = new Array<any>();
        let selectedId: [] = new Array<string>();

        for (let productList of this.eventList.ProductList) {
            selectedId.push(productList.Id);

            data.push({
                id: productList.Id,
                text: productList.Title,
                selected: true,
                Item: productList
            })
        }

        $("#productListSelect").select2({
            width: '100%',
            data: data,
            allowClear: false,
            placeholder: '',
            ajax: {
                url: this.configService.config.apiUrl + "/productList/only",
                datatype: 'json',
                delay: 500,
                data: function (params: any) {
                    return {
                        query: params.term,
                        fillOrders: true,
                    };
                },
                processResults: function (response: BaseResponse<Array<ProductList>>, params: any): any {
                    if (!response || !response.Data)
                        return [];

                    let results: any[] = response.Data.map(function (productList) {
                        return {
                            id: productList.Id,
                            text: productList.Title,
                            Item: productList
                        }
                    });

                    if (results.length == 0)
                        results.push({ id: params.term, text: params.term });

                    return {
                        results: results
                    };
                }
            },
        }).on('select2:select', function (e: any) {
            let selectedData = $(this).select2('data');

            if (!selectedData || !selectedData[0])
                return;

            self.eventList.ProductList.splice(0, self.eventList.ProductList.length);

            for (let data of selectedData) {
                self.eventList.ProductList.push(data.Item);
            }
        }).on('select2:unselect', function (e: any) {
            let selectedData = $(this).select2('data');

            if (!selectedData || !selectedData[0])
                return;

            self.eventList.ProductList.splice(0, self.eventList.ProductList.length);

            for (let data of selectedData) {
                self.eventList.ProductList.push(data.Item);
            }
        });


        $("#productListSelect").val(selectedId).change();
    }

    public initSelect2() {
        this.customerSelect();
        this.productListSelect();
    }

    public hide(): void {
        this.productListModalModal.hide();
    }

    public show(eventList: EventList, isCreated: boolean) {
        if (eventList) {
            this.eventListOrigin = eventList;
        }
        else
            this.eventListOrigin = new EventList();

        if (isCreated)
            this.isCreated = isCreated;

        this.eventList = JSON.parse(JSON.stringify(this.eventListOrigin));

        this.initSelect2();

        this.productListModalModal.show();
    }

    public save(isValid: boolean): void {
        if (this.isCreated) {
            this.eventListService.create(this.eventList).then(x => {
                this.eventListChange.emit(x.Data);
                this.eventListOrigin = x.Data;
                this.hide();
            });
        }
        else {
            this.eventListService.update(this.eventList).then(x => {
                this.eventListChange.emit(x.Data);
                this.eventListOrigin = x.Data;
                this.hide();
            });
        }
    }
}