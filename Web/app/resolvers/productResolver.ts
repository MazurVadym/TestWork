import { BaseResponse } from "../objects/common/baseResponse";
import { ActivatedRouteSnapshot } from "@angular/router";
import { ProductService } from "../services/productService";
import { Injectable } from "@angular/core";
import { Product } from "../objects/product/product";
/**
 * Created by vadim.m on 11/18/2017.
 */

@Injectable()
export class ProductResolver {

    constructor(private productService:ProductService) {
    }

    public resolve(route: ActivatedRouteSnapshot): Promise<BaseResponse<Array<Product>>> {
        return this.productService.getAll();
    }
}