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
var motivoacao_service_1 = require("./../../service/motivoacao.service");
var core_1 = require("@angular/core");
var prodesp_ui_1 = require("prodesp-ui");
var expand_table_data_1 = require("./../../models/expand.table.data");
var prodesp_ui_2 = require("prodesp-ui");
var medicamento_1 = require("../../models/medicamento");
var fluxo_justicacao_1 = require("../../models/fluxo.justicacao");
var ng2_bootstrap_modal_1 = require("ng2-bootstrap-modal");
var prodesp_monitor_modal_historico_component_1 = require("../prodesp-monitor-modal-historico/prodesp-monitor-modal-historico.component");
require("rxjs/add/operator/map");
require("rxjs/add/operator/catch");
require("rxjs/add/observable/throw");
var ProdespExpandableTable = (function () {
    function ProdespExpandableTable(dialogService, motivoAcaoService) {
        this.dialogService = dialogService;
        this.motivoAcaoService = motivoAcaoService;
        this.acoes = [];
        this.motivos = [];
        this.onRowsSelected = new core_1.EventEmitter();
        this.onPageChanges = new core_1.EventEmitter();
    }
    ProdespExpandableTable.prototype.ngOnInit = function () {
        this.initTableOptions();
        console.log(this.tableData);
        this.carregarDropDownAcao();
        this.carregarDropDownMotivo();
    };
    ProdespExpandableTable.prototype.ngOnChanges = function (changes) {
        this.toogleExpandAll();
    };
    ProdespExpandableTable.prototype.pageChanges = function (nextPage) {
        this.onPageChanges.emit(nextPage);
    };
    ProdespExpandableTable.prototype.buscarPagina = function () {
    };
    ProdespExpandableTable.prototype.carregarDropDownAcao = function () {
        var _this = this;
        this.motivoAcaoService.buscarPorTipo(0)
            .map(function (response) {
            _this.acoes = response.json();
        }).subscribe();
    };
    ProdespExpandableTable.prototype.carregarDropDownMotivo = function () {
        var _this = this;
        this.motivoAcaoService.buscarPorTipo(1)
            .map(function (response) {
            _this.motivos = response.json();
            console.log(_this.motivos);
        }).subscribe();
    };
    ProdespExpandableTable.prototype.selectAll = function () {
        for (var i = 0; i < this.tableData.length; i++) {
            this.tableData[i].selected = this.selectedAll;
        }
        var selecteds = this.obterSelecionados();
        this.onRowsSelected.emit(selecteds);
    };
    ProdespExpandableTable.prototype.checkIfAllSelected = function () {
        this.selectedAll = this.tableData.every(function (item) {
            return item.selected === true;
        });
        var selecteds = this.obterSelecionados();
        this.onRowsSelected.emit(selecteds);
    };
    ProdespExpandableTable.prototype.initTableOptions = function () {
        this.tableOptions = new prodesp_ui_2.TableOptions();
        this.tableOptions.showPerPage = [5, 10, 15, 30, 50, 100, 200];
        this.tableOptions.tableHeader = 'Ocorrencias';
        this.tableOptions.columnsDefinition = [
            new prodesp_ui_2.TableColumnDefinition('IdOcorrencia', 'Grupo de Recursos'),
            new prodesp_ui_2.TableColumnDefinition('IdTipoOcorrencia', 'Código'),
            new prodesp_ui_2.TableColumnDefinition('NomeOcorrencia', 'Un. Distribuição'),
            new prodesp_ui_2.TableColumnDefinition('DataInclusao', 'Saldo Disponível'),
            new prodesp_ui_2.TableColumnDefinition('StRegistro', 'Autonomia'),
            new prodesp_ui_2.TableColumnDefinition('', 'Data Ultima Fatura'),
            new prodesp_ui_2.TableColumnDefinition('', 'Data Ultimo Consumo'),
            new prodesp_ui_2.TableColumnDefinition('', 'CMM'),
            new prodesp_ui_2.TableColumnDefinition('', 'Justificado'),
            new prodesp_ui_2.TableColumnDefinition('', 'Justificado'),
            new prodesp_ui_2.TableColumnDefinition('', 'Ações')
        ];
    };
    ProdespExpandableTable.prototype.initTableData = function () {
        this.tableData = [
            new expand_table_data_1.ExpandTableData(new medicamento_1.Medicamento('1A', 12563, 'ABATACEPTE 250MG INJETÁVEL (POR FRASCO-AMPOLA)', 'Frasco', 1, 0, '12/02/2017', 12000, '27/10/2017', 'FME Maria Zelia', new fluxo_justicacao_1.FluxoJustificacao(true, false, false), true), false, false),
            new expand_table_data_1.ExpandTableData(new medicamento_1.Medicamento('1A', 23434, 'ADEFOVIR 10 MG (POR COMPRIMIDO)', 'Comp.', 0, 1, '20/05/2017', 5000, '27/10/2017', 'FME Maria Zelia', new fluxo_justicacao_1.FluxoJustificacao(true, false, false), true), false, false),
            new expand_table_data_1.ExpandTableData(new medicamento_1.Medicamento('1A', 34689, 'IMUNOGLOBULINA HUMANA 5,0G INJETÁVEL (POR FRASCO)', 'Frasco.', 0, 4, '20/05/2017', 3566, '27/10/2017', 'FME Maria Zelia', new fluxo_justicacao_1.FluxoJustificacao(true, false, false), true), false, false),
            new expand_table_data_1.ExpandTableData(new medicamento_1.Medicamento('1A', 12563, 'ABATACEPTE 250MG INJETÁVEL (POR FRASCO-AMPOLA)', 'Frasco', 1, 0, '12/02/2017', 12000, '27/10/2017', 'FME Maria Zelia', new fluxo_justicacao_1.FluxoJustificacao(true, false, false), true), false, false),
            new expand_table_data_1.ExpandTableData(new medicamento_1.Medicamento('1A', 23434, 'ADEFOVIR 10 MG (POR COMPRIMIDO)', 'Comp.', 0, 1, '20/05/2017', 5000, '27/10/2017', 'FME Maria Zelia', new fluxo_justicacao_1.FluxoJustificacao(true, false, false), true), false, false),
            new expand_table_data_1.ExpandTableData(new medicamento_1.Medicamento('1A', 34689, 'IMUNOGLOBULINA HUMANA 5,0G INJETÁVEL (POR FRASCO)', 'Frasco.', 0, 4, '20/05/2017', 3566, '27/10/2017', 'FME Maria Zelia', new fluxo_justicacao_1.FluxoJustificacao(true, false, false), true), false, false),
            new expand_table_data_1.ExpandTableData(new medicamento_1.Medicamento('1A', 12563, 'ABATACEPTE 250MG INJETÁVEL (POR FRASCO-AMPOLA)', 'Frasco', 1, 0, '12/02/2017', 12000, '27/10/2017', 'FME Maria Zelia', new fluxo_justicacao_1.FluxoJustificacao(true, false, false), true), false, false),
            new expand_table_data_1.ExpandTableData(new medicamento_1.Medicamento('1A', 23434, 'ADEFOVIR 10 MG (POR COMPRIMIDO)', 'Comp.', 0, 1, '20/05/2017', 5000, '27/10/2017', 'FME Maria Zelia', new fluxo_justicacao_1.FluxoJustificacao(true, false, false), true), false, false),
            new expand_table_data_1.ExpandTableData(new medicamento_1.Medicamento('1A', 34689, 'IMUNOGLOBULINA HUMANA 5,0G INJETÁVEL (POR FRASCO)', 'Frasco.', 0, 4, '20/05/2017', 3566, '27/10/2017', 'FME Maria Zelia', new fluxo_justicacao_1.FluxoJustificacao(true, false, false), true), false, false),
            new expand_table_data_1.ExpandTableData(new medicamento_1.Medicamento('1A', 12563, 'ABATACEPTE 250MG INJETÁVEL (POR FRASCO-AMPOLA)', 'Frasco', 1, 0, '12/02/2017', 12000, '27/10/2017', 'FME Maria Zelia', new fluxo_justicacao_1.FluxoJustificacao(true, false, false), true), false, false),
            new expand_table_data_1.ExpandTableData(new medicamento_1.Medicamento('1A', 23434, 'ADEFOVIR 10 MG (POR COMPRIMIDO)', 'Comp.', 0, 1, '20/05/2017', 5000, '27/10/2017', 'FME Maria Zelia', new fluxo_justicacao_1.FluxoJustificacao(true, false, false), true), false, false),
            new expand_table_data_1.ExpandTableData(new medicamento_1.Medicamento('1A', 34689, 'IMUNOGLOBULINA HUMANA 5,0G INJETÁVEL (POR FRASCO)', 'Frasco.', 0, 4, '20/05/2017', 3566, '27/10/2017', 'FME Maria Zelia', new fluxo_justicacao_1.FluxoJustificacao(true, false, false), true), false, false),
            new expand_table_data_1.ExpandTableData(new medicamento_1.Medicamento('1A', 12563, 'ABATACEPTE 250MG INJETÁVEL (POR FRASCO-AMPOLA)', 'Frasco', 1, 0, '12/02/2017', 12000, '27/10/2017', 'FME Maria Zelia', new fluxo_justicacao_1.FluxoJustificacao(true, false, false), true), false, false),
            new expand_table_data_1.ExpandTableData(new medicamento_1.Medicamento('1A', 23434, 'ADEFOVIR 10 MG (POR COMPRIMIDO)', 'Comp.', 0, 1, '20/05/2017', 5000, '27/10/2017', 'FME Maria Zelia', new fluxo_justicacao_1.FluxoJustificacao(true, false, false), true), false, false),
            new expand_table_data_1.ExpandTableData(new medicamento_1.Medicamento('1A', 34689, 'IMUNOGLOBULINA HUMANA 5,0G INJETÁVEL (POR FRASCO)', 'Frasco.', 0, 4, '20/05/2017', 3566, '27/10/2017', 'FME Maria Zelia', new fluxo_justicacao_1.FluxoJustificacao(true, false, false), true), false, false),
            new expand_table_data_1.ExpandTableData(new medicamento_1.Medicamento('1A', 12563, 'ABATACEPTE 250MG INJETÁVEL (POR FRASCO-AMPOLA)', 'Frasco', 1, 0, '12/02/2017', 12000, '27/10/2017', 'FME Maria Zelia', new fluxo_justicacao_1.FluxoJustificacao(true, false, false), true), false, false),
            new expand_table_data_1.ExpandTableData(new medicamento_1.Medicamento('1A', 23434, 'ADEFOVIR 10 MG (POR COMPRIMIDO)', 'Comp.', 0, 1, '20/05/2017', 5000, '27/10/2017', 'FME Maria Zelia', new fluxo_justicacao_1.FluxoJustificacao(true, false, false), true), false, false),
        ];
    };
    ProdespExpandableTable.prototype.toggleExpand = function (row) {
        row.expanded = !row.expanded;
    };
    ProdespExpandableTable.prototype.viewHistorico = function (row) {
        this.dialogService.addDialog(prodesp_monitor_modal_historico_component_1.ProdespMonitorModalHistoricoComponent, {
            title: 'Histórico de Justificativas',
            showConfirmButton: false,
            closeButtonText: 'Fechar',
            historico: [
                new prodesp_ui_1.Timeline('10/11/2017', 'fa-tag', 'blue', this.fakeTimelineBody(), 'sexta-feira, 10 de novembro de 2017', 'Resumo Diário'),
                new prodesp_ui_1.Timeline('10/11/2017', 'fa-tag', 'blue', this.fakeTimelineBody(), 'sexta-feira, 10 de novembro de 2017', 'Resumo Diário'),
                new prodesp_ui_1.Timeline('10/11/2017', 'fa-tag', 'blue', this.fakeTimelineBody(), 'sexta-feira, 10 de novembro de 2017', 'Resumo Diário'),
                new prodesp_ui_1.Timeline('10/11/2017', 'fa-tag', 'blue', this.fakeTimelineBody(), 'sexta-feira, 10 de novembro de 2017', 'Resumo Diário'),
                new prodesp_ui_1.Timeline('10/11/2017', 'fa-tag', 'blue', this.fakeTimelineBody(), 'sexta-feira, 10 de novembro de 2017', 'Resumo Diário'),
            ]
        });
    };
    ProdespExpandableTable.prototype.fakeTimelineBody = function () {
        return "<table class=\"table table-striped table-hover table-bordered dataTable no-footer table-responsive font-90 tablesorter\" role=\"grid\">\n         <thead>\n             <tr>\n                 <th class=\"header\">\n     \n                 </th>\n                 <th class=\"header\">\n     \n                 </th>\n     \n             </tr>\n                                                             \n         </thead>\n         <tbody>\n     \n         </tbody>\n         \n         <tbody><tr>\n             <td>Justificativa F.M.E</td>\n             <td> Paciente Novo</td>\n     \n         </tr>\n         <tr>\n             <td>A\u00E7\u00E3o F.M.E</td>\n             <td>Remanejamento</td>\n     \n         </tr>\n         <tr>\n             <td>Saldo Dispon\u00EDvel</td>\n             <td>4.000 comprimidos</td>\n     \n         </tr>\n         <tr>\n             <td>Consumo Medex (dia)</td>\n             <td>100 comprimidos</td>\n         </tr>\n         <tr>\n             <td>Fatura Emitida (CAF)</td>\n             <td>03/11/2017</td>\n         </tr>\n     </tbody></table>";
    };
    ProdespExpandableTable.prototype.obterSelecionados = function () {
        var selecteds = [];
        if (this.tableData.length === 0) {
            this.selecteds = 0;
        }
        else {
            selecteds = this.tableData.filter(function (v) {
                if (v.selected === true) {
                    return true;
                }
                return false;
            });
            return selecteds;
        }
    };
    ProdespExpandableTable.prototype.toogleExpandAll = function () {
        var _this = this;
        this.tableData.forEach(function (item) { item.expanded = _this.expandAll; });
    };
    return ProdespExpandableTable;
}());
__decorate([
    core_1.Input(),
    __metadata("design:type", Boolean)
], ProdespExpandableTable.prototype, "expandAll", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", Boolean)
], ProdespExpandableTable.prototype, "noDataFound", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", Array)
], ProdespExpandableTable.prototype, "tableData", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", Number)
], ProdespExpandableTable.prototype, "page", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", Number)
], ProdespExpandableTable.prototype, "perPage", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", Number)
], ProdespExpandableTable.prototype, "totalPages", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", String)
], ProdespExpandableTable.prototype, "errorMessage", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", prodesp_ui_2.TableOptions)
], ProdespExpandableTable.prototype, "tableOptions", void 0);
__decorate([
    core_1.Output(),
    __metadata("design:type", core_1.EventEmitter)
], ProdespExpandableTable.prototype, "onRowsSelected", void 0);
__decorate([
    core_1.Output(),
    __metadata("design:type", core_1.EventEmitter)
], ProdespExpandableTable.prototype, "onPageChanges", void 0);
ProdespExpandableTable = __decorate([
    core_1.Component({
        selector: 'prodesp-expandable-table',
        templateUrl: './prodesp-table-expandable.component.html',
        styleUrls: ['./prodesp-table-expandable.component.css']
    }),
    __metadata("design:paramtypes", [ng2_bootstrap_modal_1.DialogService, motivoacao_service_1.MotivoAcaoService])
], ProdespExpandableTable);
exports.ProdespExpandableTable = ProdespExpandableTable;
//# sourceMappingURL=prodesp-table-expandable.component.js.map