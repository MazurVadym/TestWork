import { Component, ViewEncapsulation } from "@angular/core";
import "node_modules/select2/dist/js/select2.js";
/**
 * Created by vadim.m on 11/17/2017.
 */
declare var $:any;

@Component({
    selector: 'layout',
    templateUrl: './layout.component.html',
    styleUrls: ['../../../node_modules/select2/dist/css/select2.css'],
    moduleId: module.id.toString(),
    encapsulation: ViewEncapsulation.None
})

export class LayoutComponent{

}