import { BaseApi } from "./baseApi";
import { Injectable } from "@angular/core";
import { ConfigService } from "./configService";
import { Http, RequestOptions } from "@angular/http";
import { BaseResponse } from "../objects/common/baseResponse";
import { ProductList } from "../objects/list/productList/productList";
/**
 * Created by vadim.m on 11/16/2017.
 */
@Injectable()
export class ProductListService extends BaseApi {

    constructor(http: Http, configService: ConfigService) {
        super(http, configService);
    }

    public create(productList: ProductList): Promise<BaseResponse<ProductList>> {
        return this.post(new RequestOptions({
            url: `productList`,
            body: productList
        }));
    }

    public update(productList: ProductList): Promise<BaseResponse<ProductList>> {
        return this.put(new RequestOptions({
            url: `productList`,
            body: productList
        }));
    }

    public deleteProductList(id: string): Promise<BaseResponse<any>> {
        return this.delete(new RequestOptions({
            url: `productList/${id}`,
        }));
    }

    public getAll():Promise<BaseResponse<Array<ProductList>>>{
        return this.get(new RequestOptions({
            url: `productList`,
        }));
    }

    public getById(id:string):Promise<BaseResponse<ProductList>>{
        return this.get(new RequestOptions({
            url: `productList/${id}`,
        }));
    }
}