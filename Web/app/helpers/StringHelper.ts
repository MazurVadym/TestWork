/**
 * Created by Vadym on 6/18/2017.
 */
export class StringHelper {

    public static isNullOrEmpty(value: string): boolean {
        return (value == null || value == "" || value.length == 0);
    }

    public static camelCaseToString(value: string): string {
        return value.replace(/([A-Z])/g, ' $1')
            .replace(/^./, function (str) {
                return str.toUpperCase();
            })
    }

    public static generateValues(from: number, to: number): number[] {
        let numbers: number[] = [];

        for (let i = from; i <= to; i++)
            numbers.push(i);

        return numbers;
    }

    public static replaceSpaces(value: string): string {
        return value.replace(/\s/g, '');
    }

    public static toNumberArray(arr: string[]): number[] {
        return arr.map(x => parseInt(x));
    }

}