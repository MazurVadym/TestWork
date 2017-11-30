import {Injectable} from "@angular/core";
import {Configuration} from "../objects/common/configuration";
import {Http, RequestMethod, RequestOptions,Response,Request,Headers} from "@angular/http";
import {BaseResponse} from "../objects/common/baseResponse";
import 'rxjs/add/operator/map';
import { ConfigService } from "./configService";
import { StringHelper } from "../helpers/StringHelper";
/**
 * Created by Vadym on 6/18/2017.
 */
@Injectable()
export class BaseApi {
    protected config: Configuration;

    constructor(protected http: Http, protected configService: ConfigService) {
        this.config = this.configService.config;
    }

    public get<T>(params: RequestOptions): Promise<BaseResponse<T>> {
        params.method = RequestMethod.Get;

        return this.sendRequest(params);
    }

    public post<T>(params: RequestOptions): Promise<BaseResponse<T>> {
        params.method = RequestMethod.Post;

        return this.sendRequest(params);
    }

    public put<T>(params: RequestOptions): Promise<BaseResponse<T>> {
        params.method = RequestMethod.Put;

        return this.sendRequest(params);
    }

    public delete<T>(params: RequestOptions): Promise<BaseResponse<T>> {
        params.method = RequestMethod.Delete;

        return this.sendRequest(params);
    }

    private sendRequest<T>(params: RequestOptions): Promise<BaseResponse<T>> {
        let request = this.validate(params);

        return this.http.request(request, params).map((res: Response) => {
            let jsonData = res.json();
            return new BaseResponse<T>(jsonData.Success, jsonData.Status, jsonData.Errors, jsonData.Data);
        }).toPromise().catch(x => {
            let jsonData = x.json();
            return Promise.reject(new BaseResponse<T>(jsonData.Success, jsonData.ResponseCode, jsonData.Errors, jsonData.Data));
        });
    }

    private validate(params: RequestOptions): Request {
        if (params == null) {
            params = new RequestOptions();
        }

        if (params.method == null) {
            params.method = RequestMethod.Get;
            console.log("request method is empty. Using default GET")
        }

        if (StringHelper.isNullOrEmpty(params.url)) {
            console.log("Url is empty");
        }

        if (params.headers == null)
            params.headers = new Headers();

        params.headers.append("Content-Type", 'application/json');


        params.url = `${this.config.apiUrl}/${params.url}`;

        return new Request(params);
    }
}