/**
 * Created by Vadym on 6/18/2017.
 */
export class BaseResponse<T> {

    Success: boolean;
    ResponseCode: number;
    Errors: Array<any>;
    Data: T;

    constructor(success: boolean, responseCode: number, errors: Array<any>, data: T) {
        this.Success = success;
        this.ResponseCode = responseCode;
        this.Data = data;
        this.Errors = errors;
    }

}