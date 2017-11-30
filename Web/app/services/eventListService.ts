import { Injectable } from "@angular/core";
import { BaseApi } from "./baseApi";
import { Http, RequestOptions } from "@angular/http";
import { ConfigService } from "./configService";
import { EventList } from "../objects/eventList/eventList";
import { BaseResponse } from "../objects/common/baseResponse";
/**
 * Created by vadim.m on 11/17/2017.
 */
@Injectable()
export class EventListService extends BaseApi {

    constructor(http: Http, configService: ConfigService) {
        super(http, configService);
    }

    public create(eventList: EventList): Promise<BaseResponse<EventList>> {
        return this.post(new RequestOptions({
            url: `eventList`,
            body: eventList
        }));
    }

    public update(eventList: EventList): Promise<BaseResponse<EventList>> {
        return this.put(new RequestOptions({
            url: `eventList`,
            body: eventList
        }));
    }

    public deleteEventList(id: string): Promise<BaseResponse<any>> {
        return this.delete(new RequestOptions({
            url: `eventList/${id}`,
            body: id
        }));
    }

    public getAll(): Promise<BaseResponse<Array<EventList>>> {
        return this.get(new RequestOptions({
            url: `eventList`,
        }));
    }

    public getById(id:string): Promise<BaseResponse<EventList>> {
        return this.get(new RequestOptions({
            url: `eventList/${id}`,
        }));
    }
}