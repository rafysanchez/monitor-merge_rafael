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
var fluxo_justicacao_1 = require("./../../models/fluxo.justicacao");
var core_1 = require("@angular/core");
var ProdespFluxoJustificativaComponent = (function () {
    function ProdespFluxoJustificativaComponent() {
    }
    ProdespFluxoJustificativaComponent.prototype.ngOnInit = function () {
    };
    return ProdespFluxoJustificativaComponent;
}());
__decorate([
    core_1.Input(),
    __metadata("design:type", fluxo_justicacao_1.FluxoJustificacao)
], ProdespFluxoJustificativaComponent.prototype, "fluxo", void 0);
ProdespFluxoJustificativaComponent = __decorate([
    core_1.Component({
        selector: 'prodesp-fluxo-justificativa',
        templateUrl: './prodesp-fluxo-justificativa.component.html',
        styleUrls: ['./prodesp-fluxo-justificativa.component.css']
    }),
    __metadata("design:paramtypes", [])
], ProdespFluxoJustificativaComponent);
exports.ProdespFluxoJustificativaComponent = ProdespFluxoJustificativaComponent;
//# sourceMappingURL=prodesp-fluxo-justificativa.component.js.map