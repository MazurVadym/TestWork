import { ProductList } from "../productList/productList";
import { BaseList } from "../baseList";
/**
 * Created by vadim.m on 11/17/2017.
 */

export class EventList extends BaseList {
    public Description: string;
    public Public: number;
    public ProductList: ProductList[] = new Array<ProductList>();

    public constructor(init?: Partial<EventList>) {
        super();
        Object.assign(this, init);
    }
}