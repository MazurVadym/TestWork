import { ProductItem } from "../../product/productItem";
import { BaseList } from "../baseList";
/**
 * Created by vadim.m on 11/16/2017.
 */

export class ProductList extends BaseList{
    public EventListId: string;
    public ProductItem: ProductItem[];

    public constructor(init?: Partial<ProductList>) {
        super();
        Object.assign(this, init);
    }
}