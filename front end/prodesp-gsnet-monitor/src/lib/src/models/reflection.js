"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Reflection = (function () {
    function Reflection() {
    }
    Reflection.getObjectPropertyNames = function (obj) {
        return Object.getOwnPropertyNames(obj);
    };
    Reflection.getTypeofProperty = function (o, name) {
        return typeof o[name];
    };
    return Reflection;
}());
exports.Reflection = Reflection;
//# sourceMappingURL=reflection.js.map