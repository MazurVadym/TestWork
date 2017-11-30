/**
 * Created by vadim.m on 11/19/2017.
 */
import { Component, Input, ViewChild } from "@angular/core";
import { ProductListService } from "../../../../services/productListService";
import { ProductItemService } from "../../../../services/productItemService";
import { ModalDirective } from "ngx-bootstrap";
import { Product } from "../../../../objects/product/product";
import { ProductList } from "../../../../objects/productList/productList";
import { Variant } from "../../../../objects/product/variant";
import { ProductItem } from "../../../../objects/productList/productItem";

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


    constructor(private productListService: ProductListService, private productItemService: ProductItemService) {
    }

    public hide(): void {
        this.productModal.hide();
    }

    public show(product: Product, variant: Variant): void {
        this.product = product;
        this.variant = variant;

        this.productModal.show();
    }

    public getProductAmount(productList: ProductList): number {
        if (!productList || !this.variant || !this.product)
            return 0;

        let currentProductList = productList.ProductItem.find(x => x.ProductId == this.product.Id && x.VariantId == this.variant.Id);

        if (currentProductList) {
            return currentProductList.Amount
        }

        return 0;
    }

    public addToProductList(productList: ProductList): void {
        let productItem = new ProductItem();
        productItem.ProductListId = productList.Id;
        productItem.ProductId = this.product.Id;
        productItem.VariantID = this.variant.Id;
        productItem.Amount = +document.getElementById(productList.Id).value;

        this.productItemService.create(productItem);
    }

}