/**
 * Created by vadim.m on 11/18/2017.
 */
import { Component, OnInit, ViewChild } from "@angular/core";
import { EventListService } from "../../../services/eventListService";
import { EventList } from "../../../objects/list/eventList/eventList";
import { ActivatedRoute } from "@angular/router";
import { EventListModalComponent } from "./eventListModal/eventListModal.component";

@Component({
    selector: 'event-list',
    templateUrl: 'eventList.component.html',
    moduleId: module.id.toString()
})

export class EventListComponent implements OnInit {

    public eventLists: EventList[];

    @ViewChild("eventListModal") public modal: EventListModalComponent;

    constructor(private route: ActivatedRoute, private eventListService: EventListService) {
    }

    public ngOnInit(): void {
        this.eventLists = this.route.snapshot.data.eventLists.Data
    }

    public delete(eventList: EventList): void {
        this.eventListService.deleteEventList(eventList.Id).then(x => {
            this.eventLists.splice(this.eventLists.indexOf(eventList), 1);
        })
    }

    public updateEventLists(eventList: EventList): void {
        let currentEventList = this.eventLists.find(x => x.Id == eventList.Id);
        let index = this.eventLists.indexOf(currentEventList);

        if (index > -1) {
            this.eventLists.splice(index, 1)
        }

        this.eventLists.push(eventList);
    }
}