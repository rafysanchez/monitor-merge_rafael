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
var programa_saude_model_1 = require("./../../models/programa.saude.model");
var sitaucao_justificativa_model_1 = require("./../../models/sitaucao.justificativa.model");
var ng2_bootstrap_modal_1 = require("ng2-bootstrap-modal");
var pesquisa_medicamento_model_1 = require("./../../models/pesquisa.medicamento.model");
var core_1 = require("@angular/core");
var modal_component_model_1 = require("../../models/modal.component.model");
var situacao_saldo_model_1 = require("../../models/situacao.saldo.model");
var ProdespMonitorModalPesquisaMedicamentoComponent = (function (_super) {
    __extends(ProdespMonitorModalPesquisaMedicamentoComponent, _super);
    function ProdespMonitorModalPesquisaMedicamentoComponent(dialogService) {
        var _this = _super.call(this, dialogService) || this;
        _this.situacoesSaldo = [];
        _this.situacaoJustificativa = [];
        _this.programasSaude = [];
        return _this;
    }
    ProdespMonitorModalPesquisaMedicamentoComponent.prototype.ngOnInit = function () {
        this.programasSaude = [
            new programa_saude_model_1.ProgramaSaude(null, '-- SELECIONE --'),
            new programa_saude_model_1.ProgramaSaude(1, 'DOSE CERTA'),
            new programa_saude_model_1.ProgramaSaude(2, 'DOSE CERTA'),
            new programa_saude_model_1.ProgramaSaude(3, 'ALTO CUSTO - MEDIC.ESPEC'),
            new programa_saude_model_1.ProgramaSaude(5, 'DIABETES'),
            new programa_saude_model_1.ProgramaSaude(6, 'DST/AIDS'),
            new programa_saude_model_1.ProgramaSaude(7, 'TUBERCULOSE'),
            new programa_saude_model_1.ProgramaSaude(8, 'COLERA'),
            new programa_saude_model_1.ProgramaSaude(9, 'ESQUISTOSSOMOSE'),
            new programa_saude_model_1.ProgramaSaude(10, 'TRACOMA'),
            new programa_saude_model_1.ProgramaSaude(11, 'MENINGITE'),
            new programa_saude_model_1.ProgramaSaude(12, 'LEISHMANIOSE'),
            new programa_saude_model_1.ProgramaSaude(13, 'HANSENIASE'),
            new programa_saude_model_1.ProgramaSaude(14, 'LUPUS'),
            new programa_saude_model_1.ProgramaSaude(15, 'FIBROSE CISTICA'),
            new programa_saude_model_1.ProgramaSaude(16, 'TRS'),
            new programa_saude_model_1.ProgramaSaude(17, 'GLAUCOMA'),
            new programa_saude_model_1.ProgramaSaude(18, 'MADICAMENTOS BASICOS '),
            new programa_saude_model_1.ProgramaSaude(19, 'MALARIA'),
            new programa_saude_model_1.ProgramaSaude(20, 'ESQUISTOSSOMOSE TESTE')
        ];
        this.situacoesSaldo = [
            new situacao_saldo_model_1.SituacaoSaldoMedicamento(null, 'TODOS'),
            new situacao_saldo_model_1.SituacaoSaldoMedicamento(1, 'AUTONOMIA'),
            new situacao_saldo_model_1.SituacaoSaldoMedicamento(2, 'SALDO ZERADO')
        ];
        this.situacaoJustificativa = [
            new sitaucao_justificativa_model_1.SituacaoJustificativa(null, 'TODOS'),
            new sitaucao_justificativa_model_1.SituacaoJustificativa(false, 'PENDENTES'),
            new sitaucao_justificativa_model_1.SituacaoJustificativa(true, 'JUSTIFICADOS')
        ];
        this.filtros = new pesquisa_medicamento_model_1.PesquisaMedicamento();
    };
    ProdespMonitorModalPesquisaMedicamentoComponent.prototype.pesquisarMonitoramento = function () {
        this.result = this.filtros;
    };
    return ProdespMonitorModalPesquisaMedicamentoComponent;
}(modal_component_model_1.ModalComponent));
ProdespMonitorModalPesquisaMedicamentoComponent = __decorate([
    core_1.Component({
        selector: 'prodesp-monitor-pesquisa-medicamento',
        templateUrl: './monitor-pesquisa-medicamento.component.html',
        styleUrls: ['./monitor-pesquisa-medicamento.component.css']
    }),
    __metadata("design:paramtypes", [ng2_bootstrap_modal_1.DialogService])
], ProdespMonitorModalPesquisaMedicamentoComponent);
exports.ProdespMonitorModalPesquisaMedicamentoComponent = ProdespMonitorModalPesquisaMedicamentoComponent;
//# sourceMappingURL=pesquisa-medicamento.component.js.map