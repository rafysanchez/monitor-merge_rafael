"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var indicadores_service_1 = require("./../../service/indicadores.service");
var core_1 = require("@angular/core");
var prodesp_core_1 = require("prodesp-core");
var ProdespMonitorIndicadoresComponent = (function () {
    function ProdespMonitorIndicadoresComponent(indicadoresService) {
        this.indicadoresService = indicadoresService;
    }
    ProdespMonitorIndicadoresComponent.prototype.ngOnInit = function () {
        console.log('monitoramento ' + this.indicadores);
        debugger;
        var date = new prodesp_core_1.Datetime();
    };
    return ProdespMonitorIndicadoresComponent;
}());
__decorate([
    core_1.Input(),
    __metadata("design:type", Object)
], ProdespMonitorIndicadoresComponent.prototype, "indicadores", void 0);
ProdespMonitorIndicadoresComponent = __decorate([
    core_1.Component({
        selector: 'prodesp-monitor-indicadores',
        templateUrl: './prodesp-monitor-indicadores.component.html',
        styleUrls: ['./prodesp-monitor-indicadores.component.css']
    }),
    __metadata("design:paramtypes", [indicadores_service_1.IndicadoresService])
], ProdespMonitorIndicadoresComponent);
exports.ProdespMonitorIndicadoresComponent = ProdespMonitorIndicadoresComponent;
//# sourceMappingURL=prodesp-monitor-indicadores.component.js.map