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
var config_service_1 = require("./../../service/config.service");
var core_1 = require("@angular/core");
var ProdespJustificativaComponent = (function () {
    function ProdespJustificativaComponent(appConfig) {
        this.acoes = [];
        this.motivos = [];
        debugger;
        this.idJustificador = appConfig.getConfig('IdJustificador');
    }
    ProdespJustificativaComponent.prototype.ngOnInit = function () {
    };
    return ProdespJustificativaComponent;
}());
__decorate([
    core_1.Input(),
    __metadata("design:type", Number)
], ProdespJustificativaComponent.prototype, "idItem", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", Number)
], ProdespJustificativaComponent.prototype, "idItemGsnet", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", Number)
], ProdespJustificativaComponent.prototype, "idGestor", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", Number)
], ProdespJustificativaComponent.prototype, "idJustificador", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", Array)
], ProdespJustificativaComponent.prototype, "acoes", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", Array)
], ProdespJustificativaComponent.prototype, "motivos", void 0);
ProdespJustificativaComponent = __decorate([
    core_1.Component({
        selector: 'prodesp-justificativa',
        templateUrl: './prodesp-justificativa.component.html',
        styleUrls: ['./prodesp-justificativa.component.css']
    }),
    __metadata("design:paramtypes", [config_service_1.AppConfig])
], ProdespJustificativaComponent);
exports.ProdespJustificativaComponent = ProdespJustificativaComponent;
//# sourceMappingURL=prodesp-justificativa.component.js.map