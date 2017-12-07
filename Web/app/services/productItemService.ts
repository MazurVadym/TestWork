import { BaseApi } from "./baseApi";
import { Http, RequestOptions } from "@angular/http";
import { ConfigService } from "./configService";
import { BaseResponse } from "../objects/common/baseResponse";
import { ProductItem } from "../objects/product/productItem";
import { Injectable } from "@angular/core";
/**
 * Created by vadim.m on 11/17/2017.
 */

@Injectable()
export class ProductItemService extends BaseApi {

    constructor(http: Http, configService: ConfigService) {
        super(http, configService);
    }

    public create(productItem: ProductItem): Promise<BaseResponse<ProductItem>> {
        return this.post(new RequestOptions({
            url: `productItem`,
            body: productItem
        }));
    }

    public update(productItem: ProductItem): Promise<BaseResponse<ProductItem>> {
        return this.put(new RequestOptions({
            url: `productItem`,
            body: productItem
        }));
    }

    public deleteProductItem(ids:string[]):  Promise<BaseResponse<any>> {
        return this.delete(new RequestOptions({
            url: `productItem`,
            body: ids
        }));
    }

    public getAll():Promise<BaseResponse<Array<ProductItem>>>{
        return this.get(new RequestOptions({
            url: `productItem`,
        }));
    }

    public getById(id:string):Promise<BaseResponse<ProductItem>>{
        return this.get(new RequestOptions({
            url: `productItem/${id}`,
        }));
    }
}