/**
 * Created by vadim.m on 11/19/2017.
 */
import { Component, Input, OnChanges, OnInit, SimpleChanges } from "@angular/core";
import { ProductItem } from "../../../../objects/product/productItem";
import { Variant } from "../../../../objects/product/variant";

@Component({
    selector: 'product-list-item',
    templateUrl: 'productListItem.component.html',
    moduleId: module.id.toString()
})

export class ProductListItemComponent implements OnChanges {

    @Input()
    public productItem: ProductItem;

    public currentVariant: Variant;

    public ngOnChanges(changes: SimpleChanges): void {
        this.setCurrentVariant();
    }

    public setCurrentVariant(): void {
        if (!this.productItem.Product)
            return;

        let currentVariant = this.productItem.Product.Variants.find(x => x.Id == this.productItem.VariantId);

        if (!currentVariant)
            return;

        this.currentVariant = currentVariant;
    }

}