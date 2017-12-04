/**
 * Created by vadim.m on 11/19/2017.
 */
import { Component, Input, ViewChild } from "@angular/core";
import { ModalDirective } from "ngx-bootstrap";
import { Product } from "../../../../objects/product/product";
import { ProductList } from "../../../../objects/productList/productList";
import { Variant } from "../../../../objects/product/variant";

@Component({
    selector: 'product-modal',
    templateUrl: 'productModal.component.html',
    moduleId: module.id.toString()
})

export class ProductModalComponent {

    @ViewChild("productModal") public productModal: ModalDirective;

    @Input()
    public productLists: ProductList[];

    public product: Product;
    public variant: Variant;


    constructor() {
    }

    public hide(): void {
        this.productModal.hide();
    }

    public show(product: Product, variant: Variant): void {
        this.product = product;
        this.variant = variant;

        this.productModal.show();
    }
}