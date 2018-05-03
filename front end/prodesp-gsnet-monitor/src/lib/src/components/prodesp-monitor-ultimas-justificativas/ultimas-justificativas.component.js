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
var justificativa_service_1 = require("./../../service/justificativa.service");
var core_1 = require("@angular/core");
var ProdespMonitorUltimasJustificativasComponent = (function () {
    function ProdespMonitorUltimasJustificativasComponent(justificativaService) {
        this.justificativaService = justificativaService;
        this.ultimasJustificativas = [];
    }
    ProdespMonitorUltimasJustificativasComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.justificativaService.buscarUltimasJustificativas(this.idItemGsnet, this.idJustificador, this.idGestor)
            .map(function (response) {
            var data = response.json();
            console.log('ultimas justificativas');
            _this.ultimasJustificativas = data;
        }).subscribe();
    };
    return ProdespMonitorUltimasJustificativasComponent;
}());
__decorate([
    core_1.Input(),
    __metadata("design:type", Number)
], ProdespMonitorUltimasJustificativasComponent.prototype, "idItem", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", Number)
], ProdespMonitorUltimasJustificativasComponent.prototype, "idItemGsnet", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", Number)
], ProdespMonitorUltimasJustificativasComponent.prototype, "idGestor", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", Number)
], ProdespMonitorUltimasJustificativasComponent.prototype, "idJustificador", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", String)
], ProdespMonitorUltimasJustificativasComponent.prototype, "codSetor", void 0);
ProdespMonitorUltimasJustificativasComponent = __decorate([
    core_1.Component({
        selector: 'prodesp-monitor-ultimas-justificativas',
        templateUrl: './monitor-ultimas-justificativas.component.html',
        styleUrls: ['./monitor-ultimas-justificativas.component.css']
    }),
    __metadata("design:paramtypes", [justificativa_service_1.JustificativaService])
], ProdespMonitorUltimasJustificativasComponent);
exports.ProdespMonitorUltimasJustificativasComponent = ProdespMonitorUltimasJustificativasComponent;
//# sourceMappingURL=ultimas-justificativas.component.js.map