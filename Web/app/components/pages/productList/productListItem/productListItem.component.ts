/**
 * Created by vadim.m on 11/19/2017.
 */
import { Component, Input, OnInit } from "@angular/core";
import { ProductItem } from "../../../../objects/productList/productItem";

@Component({
    selector: 'product-list-item',
    templateUrl: 'productListItem.component.html',
    moduleId: module.id.toString()
})

export class ProductListItemComponent implements OnInit {
    @Input()
    public productItem: ProductItem;

    public productFullName: string;
    public imgUrl: string;


    public ngOnInit(): void {

        if(!this.productItem.Product)
            return;

        let currentVariant = this.productItem.Product.Variants.find(x => x.Id == this.productItem.VariantId);

        if(!currentVariant)
        return;

        this.productFullName=`${this.productItem.Product.Title} ${currentVariant.Title}`;
        this.imgUrl=currentVariant.ImgUrl;
    }

}