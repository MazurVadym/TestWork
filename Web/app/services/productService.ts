import { ConfigService } from "./configService";
import { Http, RequestOptions } from "@angular/http";
import { BaseApi } from "./baseApi";
import { Injectable } from "@angular/core";
import { BaseResponse } from "../objects/common/baseResponse";
import { Product } from "../objects/product/product";
/**
 * Created by vadim.m on 11/18/2017.
 */

@Injectable()
export class ProductService extends BaseApi {

    constructor(http: Http, configService: ConfigService) {
        super(http, configService);
    }

    public getAll():Promise<BaseResponse<Array<Product>>>{
        return this.get(new RequestOptions({
            url: `product`,
        }));
    }
}