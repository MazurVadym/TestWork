/**
 * Created by vadim.m on 12/4/2017.
 */
import { Component, Input, OnChanges, OnInit, SimpleChange, SimpleChanges } from "@angular/core";
import { ProductList } from "../../../../../objects/list/productList/productList";
import { Product } from "../../../../../objects/product/product";
import { Variant } from "../../../../../objects/product/variant";
import { ProductItemService } from "../../../../../services/productItemService";
import { ProductItem } from "../../../../../objects/product/productItem";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { StringHelper } from "../../../../../helpers/StringHelper";
import { BaseResponse } from "../../../../../objects/common/baseResponse";

@Component({
    selector: 'product-item-create',
    templateUrl: 'productItemCreate.component.html',
    moduleId: module.id.toString()
})

export class ProductItemCreateComponent implements OnInit, OnChanges {

    @Input() public productList: ProductList;

    public productListOrigin: ProductList;

    @Input() public product: Product;
    @Input() public variant: Variant;
    @Input() public isShown: boolean;

    public productItemCreateForm: FormGroup;

    public productItem: ProductItem;

    constructor(private productItemService: ProductItemService, private fb: FormBuilder) {
    }

    public ngOnInit(): void {
        this.setCurrentProductItem();
        this.buildForm();
    }

    public ngOnChanges(changes: { [propName: string]: SimpleChange }): void {
        this.setCurrentProductItem();

        if (changes['isShown'] == undefined)//todo
            return;

        if (changes['isShown'].currentValue) {
            this.cloneProductList();
        }
        else {
            this.restoreProductList();
        }

    }

    public cloneProductList(): void {
        this.productListOrigin = JSON.parse(JSON.stringify(this.productList));
    }

    public restoreProductList(): void {
        this.productList = this.productListOrigin;
    }

    public buildForm(): void {
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

        if (StringHelper.isNullOrEmpty(this.productItem.Id))//for rest
            this.productItemService.create(this.productItem).then(resp => {
                this.processModifyResponse(resp);
            });
        else
            this.productItemService.update(this.productItem).then(resp => {
                this.processModifyResponse(resp);
            });
    }

    public processModifyResponse(resp: BaseResponse<ProductItem>) {//todo
        this.productListOrigin = JSON.parse(JSON.stringify(this.productList));
    }
}