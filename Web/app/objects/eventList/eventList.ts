import { ProductList } from "../productList/productList";
/**
 * Created by vadim.m on 11/17/2017.
 */

export class EventList {
    public Id: string;
    public OwnerId: string;
    public OwnerFullName:string;
    public Title: string;
    public Active: boolean;
    public Description: string;
    public Created: Date;
    public Updated: Date;
    public Flags: number;
    public Public: number;
    public ProductList: ProductList[]=new Array<ProductList>();

    public constructor(init?: Partial<EventList>) {
        Object.assign(this, init);
    }
}