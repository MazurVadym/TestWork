import { EventListService } from "../services/eventListService";
import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot } from "@angular/router";
import { BaseResponse } from "../objects/common/baseResponse";
import { EventList } from "../objects/eventList/eventList";
/**
 * Created by vadim.m on 11/18/2017.
 */

@Injectable()
export class EventListResolver {

    constructor(private eventListService:EventListService) {
    }

    public resolve(route: ActivatedRouteSnapshot): Promise<BaseResponse<Array<EventList>>> {
        return this.eventListService.getAll();
    }
}