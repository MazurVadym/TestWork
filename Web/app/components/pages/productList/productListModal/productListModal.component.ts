import { ModalDirective } from "ngx-bootstrap";
import { Component, EventEmitter, OnInit, Output, ViewChild } from "@angular/core";
import { ProductList } from "../../../../objects/productList/productList";
import { ProductListService } from "../../../../services/productListService";
import { ConfigService } from "../../../../services/configService";
import { BaseResponse } from "../../../../objects/common/baseResponse";
import { Customer } from "../../../../objects/customer/customer";
/**
 * Created by vadim.m on 11/17/2017.
 */

declare var $: any;

@Component({
    selector: "product-list-modal",
    templateUrl: "productListModal.component.html",
    moduleId: module.id.toString()
})

export class ProductListModalComponent implements OnInit {

    @Output()
    public productListChange: EventEmitter<ProductList> = new EventEmitter<ProductList>();

    @ViewChild("productListModal") public productListModal: ModalDirective;

    public productList: ProductList = new ProductList();
    public productListOrigin: ProductList = new ProductList();

    public isCreate: boolean = true;

    constructor(private productListService: ProductListService, private configService: ConfigService) {
    }

    public ngOnInit(): void {
        this.initSelect2();

        this.productListModal.onHidden.subscribe((x: any) => this.destroy());
    }

    public destroy(): void {


        $("#customerSelect").select2('destroy');
    }

    public initSelect2() {
        let self = this;

        let data = [
            {
                id: this.productList.OwnerId,
                text: this.productList.OwnerFullName,
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

            self.productList.OwnerId = selectedData[0].id;
        });

        $("#customerSelect").val(this.productList.OwnerId).change();

    }

    public hide(): void {
        this.productListModal.hide();
    }

    public show(productList: ProductList, isCreated: boolean) {
        if (productList)
            this.productListOrigin = productList;
        else
            this.productListOrigin = new ProductList();

        if (isCreated)
            this.isCreate = isCreated;

        this.productList = JSON.parse(JSON.stringify(this.productListOrigin));

        this.initSelect2();

        this.productListModal.show();
    }

    public save(isValid: boolean): void {
        if (this.isCreated) {
            this.productListService.create(this.productList).then(x => {
                this.productListChange.emit(x.Data);
                this.productListOrigin = x.Data;
                this.hide();
            });
        }
        else {
            this.productListService.update(this.productList).then(x => {
                this.productListChange.emit(x.Data);
                this.productListOrigin = x.Data;
                this.hide();
            });
        }
    }
}
