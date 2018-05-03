export class Reflection {
    static getObjectPropertyNames(obj: Object) {
        return Object.getOwnPropertyNames(obj);
    }
    static getTypeofProperty<T, K extends keyof T>(o: T, name: K) {
        return typeof o[name];
    }
}
