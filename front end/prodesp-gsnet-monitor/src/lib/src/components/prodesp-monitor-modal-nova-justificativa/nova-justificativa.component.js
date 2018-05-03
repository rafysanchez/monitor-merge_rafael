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
var ng2_bootstrap_modal_1 = require("ng2-bootstrap-modal");
var motivoacao_service_1 = require("./../../service/motivoacao.service");
var motivo_1 = require("./../../models/motivo");
var justificativa_1 = require("./../../models/justificativa");
var core_1 = require("@angular/core");
var acao_1 = require("../../models/acao");
require("rxjs/add/operator/map");
require("rxjs/add/operator/catch");
require("rxjs/add/observable/throw");
var modal_component_model_1 = require("../../models/modal.component.model");
var ProdespMonitorModalNovaJustificativaComponent = (function (_super) {
    __extends(ProdespMonitorModalNovaJustificativaComponent, _super);
    function ProdespMonitorModalNovaJustificativaComponent(motivoAcaoService, dialogService) {
        var _this = _super.call(this, dialogService) || this;
        _this.motivoAcaoService = motivoAcaoService;
        _this.acoes = [];
        _this.motivos = [];
        return _this;
    }
    ProdespMonitorModalNovaJustificativaComponent.prototype.ngOnInit = function () {
        this.novaJustificativa = new justificativa_1.Justificativa();
        this.motivoSelecionado = new motivo_1.Motivo();
        this.acaoSelecionado = new acao_1.Acao();
        console.log(this.novaJustificativa);
        this.carregarDropDownMotivo();
        this.carregarDropDownAcao();
    };
    ProdespMonitorModalNovaJustificativaComponent.prototype.carregarDropDownAcao = function () {
        var _this = this;
        this.motivoAcaoService.buscarPorTipo(0)
            .map(function (response) {
            var data = response.json();
            _this.acoes = data;
        }).subscribe();
    };
    ProdespMonitorModalNovaJustificativaComponent.prototype.carregarDropDownMotivo = function () {
        var _this = this;
        this.motivoAcaoService.buscarPorTipo(1)
            .map(function (response) {
            _this.motivos = response.json();
        }).subscribe();
    };
    ProdespMonitorModalNovaJustificativaComponent.prototype.salvarNovaJustificativa = function (justificativa) {
        this.result = this.novaJustificativa;
        this.close();
    };
    ProdespMonitorModalNovaJustificativaComponent.prototype.closeModal = function () {
        this.close();
    };
    ProdespMonitorModalNovaJustificativaComponent.prototype.onMotivoChange = function (item) {
        var id = parseInt(item.split(':')[1].trim());
        this.motivoSelecionado = this.motivos.find(function (x) { return x.Id === id; });
    };
    ProdespMonitorModalNovaJustificativaComponent.prototype.onAcaoChange = function (item) {
        var id = parseInt(item.split(':')[1].trim());
        this.acaoSelecionado = this.acoes.find(function (x) { return x.Id === id; });
    };
    return ProdespMonitorModalNovaJustificativaComponent;
}(modal_component_model_1.ModalComponent));
ProdespMonitorModalNovaJustificativaComponent = __decorate([
    core_1.Component({
        selector: 'prodesp-monitor-modal-nova-justificativa',
        templateUrl: './monitor-modal-nova-justificativa.component.html',
        styleUrls: ['./monitor-modal-nova-justificativa.component.css']
    }),
    __metadata("design:paramtypes", [motivoacao_service_1.MotivoAcaoService, ng2_bootstrap_modal_1.DialogService])
], ProdespMonitorModalNovaJustificativaComponent);
exports.ProdespMonitorModalNovaJustificativaComponent = ProdespMonitorModalNovaJustificativaComponent;
//# sourceMappingURL=nova-justificativa.component.js.map