/**
 * Created by vadim.m on 12/4/2017.
 */
import { Component, Input, OnChanges, OnInit, SimpleChanges } from "@angular/core";
import { ProductList } from "../../../../../objects/productList/productList";
import { Product } from "../../../../../objects/product/product";
import { Variant } from "../../../../../objects/product/variant";
import { ProductItemService } from "../../../../../services/productItemService";
import { ProductItem } from "../../../../../objects/productList/productItem";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { StringHelper } from "../../../../../helpers/StringHelper";

@Component({
    selector: 'product-item-create',
    templateUrl: 'productItemCreate.component.html',
    moduleId: module.id.toString()
})

export class ProductItemCreateComponent implements OnInit, OnChanges{

    @Input() public productList: ProductList;

    @Input() public product: Product;
    @Input() public variant: Variant;

    public productItemCreateForm: FormGroup;

    public productItem: ProductItem;

    constructor(private productItemService: ProductItemService, private fb: FormBuilder) {
    }

    public ngOnInit(): void {
        this.setCurrentProductItem();
        this.buildForm();
    }

    public ngOnChanges() :void{
        this.setCurrentProductItem()
    }

    public buildForm():void {
        this.productItemCreateForm = this.fb.group({
            "amount": ["", [
                Validators.required,
                Validators.pattern("^[0-9]+$")
            ]],
        })
    }

    public setCurrentProductItem(): void {
        let currentProductItem = this.productList.ProductItem.find(x => x.ProductId == this.product.Id && x.VariantId == this.variant.Id);

        if (currentProductItem) {
            this.productItem = currentProductItem;
        }
        else {
            this.productItem = new ProductItem({ ProductListId: this.productList.Id, ProductId: this.product.Id, VariantId: this.variant.Id, Amount: 0 });
        }
    }

    public addToProductList(isValid: boolean): void {
        if (!isValid) return;

        if(StringHelper.isNullOrEmpty(this.productItem.Id))//for rest
            this.productItemService.create(this.productItem);
        else
            this.productItemService.update(this.productItem);
    }
}