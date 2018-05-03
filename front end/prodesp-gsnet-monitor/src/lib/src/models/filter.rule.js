"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var FilterRule = (function () {
    function FilterRule(Field, Value, Condition, Operator, Type, Rules) {
        if (Condition === void 0) { Condition = 'AND'; }
        this.Field = Field;
        this.Value = Value;
        this.Condition = Condition;
        this.Operator = Operator;
        this.Type = Type;
        this.Rules = Rules;
    }
    FilterRule.prototype.convertType = function (type) {
        switch (type) {
            case 'number':
                return 'integer';
            default: return type;
        }
    };
    return FilterRule;
}());
exports.FilterRule = FilterRule;
//# sourceMappingURL=filter.rule.js.map