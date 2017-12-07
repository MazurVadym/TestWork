/**
 * Created by vadim.m on 11/16/2017.
 */
import { Component, OnInit, ViewChild } from "@angular/core";
import { ProductListService } from "../../../services/productListService";
import { ProductList } from "../../../objects/list/productList/productList";
import { ActivatedRoute } from "@angular/router";
import { ProductListModalComponent } from "./ProductListModal/productListModal.component";

@Component({
    selector: 'product-list',
    templateUrl: 'productList.component.html',
    moduleId: module.id.toString()
})

export class ProductListComponent implements OnInit {

    @ViewChild('productListModal') public modal: ProductListModalComponent;

    public productLists: ProductList[];

    constructor(private route: ActivatedRoute, private productListService: ProductListService) {

    }

    public ngOnInit(): void {
        this.productLists = this.route.snapshot.data.productLists.Data
    }

    public delete(productList: ProductList): void {
        this.productListService.deleteProductList(productList.Id).then(() => {
            this.productLists.splice(this.productLists.indexOf(productList), 1);//todo check resp
        });
    }

    public updateProductLists(productList: ProductList): void {
        let currentProductList = this.productLists.find(x => x.Id == productList.Id);
        let index = this.productLists.indexOf(currentProductList);

        if (index > -1) {
            this.productLists.splice(index, 1)
        }

        this.productLists.push(productList);
    }
}