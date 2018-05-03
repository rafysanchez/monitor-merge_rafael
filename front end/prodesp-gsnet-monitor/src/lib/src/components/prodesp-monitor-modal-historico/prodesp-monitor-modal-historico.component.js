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
var prodesp_monitor_modal_confirm_component_1 = require("./../prodesp-monitor-modal-confirm/prodesp-monitor-modal-confirm.component");
var justificativa_service_1 = require("./../../service/justificativa.service");
var ng2_bootstrap_modal_1 = require("ng2-bootstrap-modal");
var core_1 = require("@angular/core");
var prodesp_ui_1 = require("prodesp-ui");
var modal_component_model_1 = require("../../models/modal.component.model");
var ProdespMonitorModalHistoricoComponent = (function (_super) {
    __extends(ProdespMonitorModalHistoricoComponent, _super);
    function ProdespMonitorModalHistoricoComponent(justificativaService, dialogService) {
        var _this = _super.call(this, dialogService) || this;
        _this.justificativaService = justificativaService;
        _this.historico = [];
        return _this;
    }
    ProdespMonitorModalHistoricoComponent.prototype.ngOnInit = function () {
        var _this = this;
        console.log(this.historico);
        this.justificativaService.buscarHistorico(this.idItemGsNet, this.idPrograma, this.idGestor).map(function (response) {
            var data = response.json();
            if (!data.length) {
                _this.showAlertDialog('O item selecionado não possui historico de justificativas', 'Item histórico de justificativas', 'Fechar').subscribe(function (result) {
                    _this.closeModal();
                });
            }
            else {
                data.map(function (item) {
                    _this.historico.push(new prodesp_ui_1.Timeline(item.DataInicioVigencia, 'fa-tag', 'blue', _this.makeTimelineBody(item), item.DataMonitoramentoExtenso, 'Resumo Diário'));
                });
            }
        }).subscribe();
    };
    ProdespMonitorModalHistoricoComponent.prototype.showAlertDialog = function (msg, title, closeButtonText) {
        return this.dialogService.addDialog(prodesp_monitor_modal_confirm_component_1.ProdespMonitorModalConfirmComponent, {
            title: title,
            text: msg,
            closeButtonText: closeButtonText,
            showConfirmButton: false
        });
    };
    ProdespMonitorModalHistoricoComponent.prototype.makeTimelineBody = function (item) {
        return "\n    <div class='table-responsive'>\n    <table class=\"table table-striped table-hover table-bordered dataTable no-footer table-responsive font-90 tablesorter\" role=\"grid\">\n       <thead>\n          <tr>\n             <th class=\"header\">\n             </th>\n             <th class=\"header\">\n             </th>\n          </tr>\n       </thead>\n       <tbody>\n          <tr>\n             <td colspan='2'><strong>F.M.E:</strong> " + item.JustificativaFME + "</td>\n          </tr>\n          <tr>\n             <td colspan='2'><strong>C.A.F:</strong> " + item.JustificativaCAF + "</td>\n          </tr>\n          <tr>\n             <td colspan='2'><strong>C.A.F P\u00FAblica:</strong>" + item.JustificativaCAFPublica + "</td>\n          </tr>\n          <tr>\n             <td colspan='2'> <strong>Compras:</strong> " + item.JustificativaCompras + "</td>\n          </tr>\n          <tr>\n             <td>Saldo Dispon\u00EDvel</td>\n             <td>" + item.SaldoDisponivel + "</td>\n          </tr>\n          <tr>\n             <td>Consumo Medex (dia)</td>\n             <td>" + item.ConsumoMedex + "</td>\n          </tr>\n          <tr>\n             <td>Fatura Emitida (CAF)</td>\n             <td>" + item.DataUltimaFatura + "</td>\n          </tr>\n          <tr>\n            <td>Ultimo Empenho</td>\n            <td>" + item.DataUltimoEmpenho + "</td>\n          </tr>\n       </tbody>\n    </table>\n </div>";
    };
    return ProdespMonitorModalHistoricoComponent;
}(modal_component_model_1.ModalComponent));
ProdespMonitorModalHistoricoComponent = __decorate([
    core_1.Component({
        selector: 'prodesp-monitor-modal-historico',
        templateUrl: './prodesp-monitor-modal-historico.component.html',
        styleUrls: ['./prodesp-monitor-modal-historico.component.css']
    }),
    __metadata("design:paramtypes", [justificativa_service_1.JustificativaService, ng2_bootstrap_modal_1.DialogService])
], ProdespMonitorModalHistoricoComponent);
exports.ProdespMonitorModalHistoricoComponent = ProdespMonitorModalHistoricoComponent;
//# sourceMappingURL=prodesp-monitor-modal-historico.component.js.map