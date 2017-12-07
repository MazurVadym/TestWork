/**
 * Created by vadim.m on 11/19/2017.
 */
import { AfterViewInit, Component, Input, OnInit, ViewChild } from "@angular/core";
import { Product } from "../../../../objects/product/product";
import { Variant } from "../../../../objects/product/variant";
import { ProductModalComponent } from "../productModal/productModal.component";
import { ProductList } from "../../../../objects/productList/productList";

declare var $: any;

@Component({
    selector: 'product-item',
    templateUrl: 'productItem.component.html',
    moduleId: module.id.toString()
})

export class ProductItemComponent implements OnInit, AfterViewInit {

    @Input()
    public product: Product;

    @Input()
    public productLists:ProductList[];

    @ViewChild('productModal') public modal: ProductModalComponent;

    public selectedVariant: Variant;

    public ngOnInit(): void {
        this.selectedVariant = this.product.Variants[0];
    }

    public ngAfterViewInit(): void {
        this.initSelect2();
    }

    public initSelect2(): void {
        let data: any[] = [];

        for (let item of this.product.Variants) {
            data.push({
                id: item.Id,
                text: item.Title,
                item: item,
            });
        }

        let self = this;

        $(`#${this.product.Id}`).select2({
            data: data
        }).on('select2:select', function (e: any) {
            let selectedData = $(this).select2('data');

            self.selectedVariant = selectedData[0].item;
        });
    }

}