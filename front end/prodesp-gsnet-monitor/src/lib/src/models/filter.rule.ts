export class FilterRule {
    constructor(
    public Field?: string,
    public Value?: string,
    public Condition: string = 'AND',
    public Operator?: string,
    public Type?: string,
    public Rules?: FilterRule[]){
    }

    public convertType(type: string) {
        switch (type) {
        case 'number' :
            return 'integer';
        default : return type;
        }
    }
}
