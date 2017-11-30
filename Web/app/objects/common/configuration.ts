/**
 * Created by Vadym on 6/18/2017.
 */
export class Configuration{
    public apiUrl: string;

    public constructor(init?:Partial<Configuration>) {
        Object.assign(this, init);
    }
}