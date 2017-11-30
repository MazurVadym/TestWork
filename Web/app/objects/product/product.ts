import { Variant } from "./variant";
/**
 * Created by vadim.m on 11/18/2017.
 */
export class Product {
    public Id: number;
    public Title: string;
    public ImgUrl: string;
    public Variants: Variant[];
}
