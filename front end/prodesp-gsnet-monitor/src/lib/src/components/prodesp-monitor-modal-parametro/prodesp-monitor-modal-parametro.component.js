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
var modal_component_model_1 = require("../../models/modal.component.model");
var dialog_service_1 = require("ng2-bootstrap-modal/dist/dialog.service");
var core_1 = require("@angular/core");
var parametro_service_1 = require("../../service/parametro.service");
var tipoacaomotivo_1 = require("./../../models/tipoacaomotivo");
var ProdespMonitorModalParametroComponent = (function (_super) {
    __extends(ProdespMonitorModalParametroComponent, _super);
    function ProdespMonitorModalParametroComponent(dialogService, service) {
        var _this = _super.call(this, dialogService) || this;
        _this.service = service;
        _this.mensagem = null;
        _this.Tipos = [];
        return _this;
    }
    ProdespMonitorModalParametroComponent.prototype.ngOnInit = function () {
        this.Tipos = [
            new tipoacaomotivo_1.TipoAcaoMotivo(0, 'Ação'),
            new tipoacaomotivo_1.TipoAcaoMotivo(1, 'Motivo'),
        ];
        this.carregaComboNomeprogramas();
    };
    ProdespMonitorModalParametroComponent.prototype.ngOnChanges = function (changes) {
    };
    ProdespMonitorModalParametroComponent.prototype.confirm = function (data) {
        this.result = this.novoParametro;
        this.closeModal();
    };
    ProdespMonitorModalParametroComponent.prototype.carregaComboNomeprogramas = function () {
        var _this = this;
        this.service.getHttpContext().get("http://localhost:57428/api/programasaude/ListarProgramasSaude").map(function (response) {
            var data = response.json();
            _this.comboData = data;
            console.log(data);
        }).subscribe();
    };
    ProdespMonitorModalParametroComponent.prototype.limparMotivoAcao = function () {
        this.novoParametro.NomePrograma = '';
        this.novoParametro.NomeTipoParametro = '';
        this.novoParametro.ConsumoMensal = '';
        this.novoParametro.Autonomia = '';
        this.novoParametro.FormulaCalculo = '';
    };
    ProdespMonitorModalParametroComponent.prototype.mostrarMensagemSucesso = function (mensagem) {
        var _this = this;
        this.mensagem = mensagem;
        setTimeout(function () { return _this.mensagem = null; }, 3000);
    };
    return ProdespMonitorModalParametroComponent;
}(modal_component_model_1.ModalComponent));
ProdespMonitorModalParametroComponent = __decorate([
    core_1.Component({
        selector: 'app-prodesp-monitor-modal-parametro',
        templateUrl: './prodesp-monitor-modal-parametro.component.html',
        styleUrls: ['./prodesp-monitor-modal-parametro.component.css']
    }),
    __metadata("design:paramtypes", [dialog_service_1.DialogService, parametro_service_1.ParametroService])
], ProdespMonitorModalParametroComponent);
exports.ProdespMonitorModalParametroComponent = ProdespMonitorModalParametroComponent;
//# sourceMappingURL=prodesp-monitor-modal-parametro.component.js.map