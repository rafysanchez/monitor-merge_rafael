"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
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
var motivo_1 = require("./../../models/motivo");
var justificativa_1 = require("./../../models/justificativa");
var ng2_bootstrap_modal_1 = require("ng2-bootstrap-modal");
var core_1 = require("@angular/core");
var acao_service_1 = require("../../service/acao.service");
var motivo_service_1 = require("../../service/motivo.service");
var acao_1 = require("../../models/acao");
var ProdespMonitorModalNovaJustificativaComponent = (function (_super) {
    __extends(ProdespMonitorModalNovaJustificativaComponent, _super);
    function ProdespMonitorModalNovaJustificativaComponent(acaoService, motivoService, dialogService) {
        var _this = _super.call(this, dialogService) || this;
        _this.acaoService = acaoService;
        _this.motivoService = motivoService;
        _this.acoes = [];
        _this.motivos = [];
        return _this;
    }
    ProdespMonitorModalNovaJustificativaComponent.prototype.ngOnInit = function () {
        this.novaJustificativa = new justificativa_1.Justificativa(new acao_1.Acao(), new motivo_1.Motivo());
        console.log(this.novaJustificativa);
        this.acoes = this.acaoService.get();
        this.motivos = this.motivoService.get();
        this.novaJustificativa.acao = this.acao;
        this.novaJustificativa.motivo = this.motivo;
    };
    ProdespMonitorModalNovaJustificativaComponent.prototype.salvarNovaJustificativa = function (justificativa) {
        alert('Salvou a justificativa');
        this.result = justificativa;
        this.close();
    };
    ProdespMonitorModalNovaJustificativaComponent.prototype.closeModal = function () {
        this.close();
    };
    return ProdespMonitorModalNovaJustificativaComponent;
}(ng2_bootstrap_modal_1.DialogComponent));
ProdespMonitorModalNovaJustificativaComponent = __decorate([
    core_1.Component({
        selector: 'prodesp-monitor-modal-nova-justificativa',
        templateUrl: './prodesp-monitor-modal-nova-justificativa.component.html',
        styleUrls: ['./prodesp-monitor-modal-nova-justificativa.component.css']
    }),
    __metadata("design:paramtypes", [acao_service_1.AcaoService, motivo_service_1.MotivoService, ng2_bootstrap_modal_1.DialogService])
], ProdespMonitorModalNovaJustificativaComponent);
exports.ProdespMonitorModalNovaJustificativaComponent = ProdespMonitorModalNovaJustificativaComponent;
//# sourceMappingURL=prodesp-monitor-modal-nova-justificativa.component.js.map