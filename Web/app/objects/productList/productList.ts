import { ProductItem } from "./productItem";
/**
 * Created by vadim.m on 11/16/2017.
 */

export class ProductList {
    public Id: string;
    public EventListId: string;
    public Title: string;
    public OwnerId: string;
    public OwnerFullName
    public Active: boolean;
    public Created: Date;
    public Updated: Date;
    public Flags: number;
    public ProductItem: ProductItem[];

    public constructor(init?: Partial<ProductList>) {
        Object.assign(this, init);
    }
}