/**
 * Created by vadim.m on 11/18/2017.
 */

import { Component, OnInit, ViewChild } from "@angular/core";
import { Product } from "../../../objects/product/product";
import { ActivatedRoute } from "@angular/router";
import { ProductList } from "../../../objects/list/productList/productList";
import { ProductModalComponent } from "./productModal/productModal.component";


@Component({
    selector: 'product',
    templateUrl: 'product.component.html',
    moduleId: module.id.toString()
})

export class ProductComponent implements OnInit{
    public products: Product[];
    public productLists:ProductList[];

    @ViewChild('productModal') public modal: ProductModalComponent;

    constructor(private route: ActivatedRoute) {

    }

    public ngOnInit(): void {
        this.products = this.route.snapshot.data.products.Data;
        this.productLists = this.route.snapshot.data.productLists.Data;
    }
}