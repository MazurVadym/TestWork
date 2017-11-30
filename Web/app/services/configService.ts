import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/toPromise';
import { Injectable } from "@angular/core";
import { Configuration } from "../objects/common/configuration";
import { Http } from "@angular/http";

@Injectable()
export class ConfigService {

    public config: Configuration = null;

    public getConfig(): Promise<Configuration> | Configuration {
        if (this.config != null)
            return this.config;

        return this.load();
    }

    constructor(private http: Http) {
    }

    static makeId() {
        let text = "";
        let possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        for (let i = 0; i < 10; i++)
            text += possible.charAt(Math.floor(Math.random() * possible.length));

        return text;
    }

    load(): Promise<Configuration> {

        let url = 'app/configuration.json';

        url += '?id=' + ConfigService.makeId();

        return this.http.get(url).toPromise().then(x => {
            this.config = x.json();
            return this.config;
        });
    }

}