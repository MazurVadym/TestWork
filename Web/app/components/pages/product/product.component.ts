/**
 * Created by vadim.m on 11/18/2017.
 */

import { Component, OnInit } from "@angular/core";
import { Product } from "../../../objects/product/product";
import { ActivatedRoute } from "@angular/router";
import { ProductService } from "../../../services/productService";
import { ProductListService } from "../../../services/productListService";
import { ProductList } from "../../../objects/productList/productList";


@Component({
    selector: 'product',
    templateUrl: 'product.component.html',
    moduleId: module.id.toString()
})

export class ProductComponent implements OnInit{
    public products: Product[];
    public productLists:ProductList[];

    constructor(private route: ActivatedRoute, private productService: ProductService) {

    }

    public ngOnInit(): void {
        this.products = this.route.snapshot.data.products.Data;
        this.productLists = this.route.snapshot.data.productLists.Data;
    }
}