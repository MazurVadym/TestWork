import { Product } from "../product/product";
/**
 * Created by vadim.m on 11/16/2017.
 */
export class ProductItem {
    public Id: string;
    public ProductListId: string;
    public ProductId: number;
    public VariantId: number;
    public Amount: number;
    public Product:Product;

    public constructor(init?:Partial<ProductItem>) {
        Object.assign(this, init);
    }
}