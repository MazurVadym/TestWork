import { ProductList } from "../objects/productList/productList";
import { ActivatedRouteSnapshot } from "@angular/router";
import { Injectable } from "@angular/core";
import { ProductListService } from "../services/productListService";
import { BaseResponse } from "../objects/common/baseResponse";
/**
 * Created by vadim.m on 11/18/2017.
 */

@Injectable()
export class ProductListResolver {

    constructor(private productListService:ProductListService) {
    }

    public resolve(route: ActivatedRouteSnapshot): Promise<BaseResponse<Array<ProductList>>> {
        return this.productListService.getAll();
    }
}