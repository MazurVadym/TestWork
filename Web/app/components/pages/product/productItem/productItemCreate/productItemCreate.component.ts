/**
 * Created by vadim.m on 12/4/2017.
 */
import { Component, Input, OnInit } from "@angular/core";
import { ProductList } from "../../../../../objects/productList/productList";
import { Product } from "../../../../../objects/product/product";
import { Variant } from "../../../../../objects/product/variant";
import { ProductItemService } from "../../../../../services/productItemService";
import { ProductItem } from "../../../../../objects/productList/productItem";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";

@Component({
    selector: 'product-item-create',
    templateUrl: 'productItemCreate.component.html',
    moduleId: module.id.toString()
})

export class ProductItemCreateComponent implements OnInit {

    @Input() public productList: ProductList;

    @Input() public product: Product;
    @Input() public variant: Variant;

    public amount: number;

    public productItemCreateForm: FormGroup;

    constructor(private productItemService: ProductItemService, private fb: FormBuilder) {
    }

    public ngOnInit(): void {
        this.buildForm();
    }

    public buildForm() {
        this.productItemCreateForm = this.fb.group({
            "amount": ["", [
                Validators.required,
                Validators.pattern("^[0-9]+$")
            ]],
        })
    }

    public getProductAmount(): number {
        if (!this.productList || !this.variant || !this.product)
            return 0;

        let currentProductList = this.productList.ProductItem.find(x => x.ProductId == this.product.Id && x.VariantId == this.variant.Id);

        if (currentProductList) {
            return currentProductList.Amount
        }

        return 0;
    }

    public addToProductList(isValid: boolean): void {
        if (!isValid) return;

        let productItem = new ProductItem({ ProductListId: this.productList.Id, ProductId: this.product.Id, VariantId: this.variant.Id, Amount: this.amount });

        this.productItemService.create(productItem);
    }
}