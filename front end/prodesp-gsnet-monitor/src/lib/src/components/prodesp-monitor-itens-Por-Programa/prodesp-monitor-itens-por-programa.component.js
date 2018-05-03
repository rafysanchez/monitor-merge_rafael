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
var expand_table_data_1 = require("../../models/expand.table.data");
var filter_rule_1 = require("./../../models/filter.rule");
var reflection_1 = require("./../../models/reflection");
var searchrequest_1 = require("./../../models/searchrequest");
var justificativa_service_1 = require("../../service/justificativa.service");
var pesquisa_medicamento_component_1 = require("./../prodesp-monitor-modal-pesquisa-medicamento/pesquisa-medicamento.component");
var ng2_bootstrap_modal_1 = require("ng2-bootstrap-modal");
var core_1 = require("@angular/core");
var pesquisa_medicamento_model_1 = require("../../models/pesquisa.medicamento.model");
var prodesp_ui_1 = require("prodesp-ui");
var ProdespMonitorItensPorProgramaComponent = (function () {
    function ProdespMonitorItensPorProgramaComponent(dialogService, justificativaService, service) {
        this.dialogService = dialogService;
        this.justificativaService = justificativaService;
        this.service = service;
        this.linhasSelecionadas = [];
        this.tableData = [];
        this.showPerPage = [5, 10, 15, 20, 50, 100, 200];
        this.perPage = 5;
        this.page = 1;
        this.expandMode = 'Expandir Todos';
        this.expanded = false;
        this.idJustificador = 1;
    }
    ProdespMonitorItensPorProgramaComponent.prototype.ngOnInit = function () {
        this.filtros = new pesquisa_medicamento_model_1.PesquisaMedicamento();
        this.tableConfig = new prodesp_ui_1.TableOptions();
        this.tableConfig.showPerPage = [5, 15, 20, 100, 200, 300];
        this.tableConfig.tableHeader = 'Farmácia';
        this.tableConfig.columnsDefinition = [
            new prodesp_ui_1.TableColumnDefinition('', 'Grupo de recurso'),
            new prodesp_ui_1.TableColumnDefinition('', 'Código'),
            new prodesp_ui_1.TableColumnDefinition('', 'SIAFISICO'),
            new prodesp_ui_1.TableColumnDefinition('', 'Nome do Item'),
            new prodesp_ui_1.TableColumnDefinition('', 'Unid. Distribuição'),
            new prodesp_ui_1.TableColumnDefinition('', 'Status'),
            new prodesp_ui_1.TableColumnDefinition('', 'Ações')
        ];
        this.buscarPagina(this.totalPages);
    };
    ProdespMonitorItensPorProgramaComponent.prototype.abrirPesquisa = function () {
        var _this = this;
        this.dialogService.addDialog(pesquisa_medicamento_component_1.ProdespMonitorModalPesquisaMedicamentoComponent, {
            title: 'Pesquisar Medicamentos',
            closeButtonText: 'Fechar',
            confirmButtonText: 'Pesquisar',
            showConfirmButton: true,
            justificador: 1,
            filtros: this.filtros,
            isClickDisabled: false,
        }).subscribe(function (data) {
            if (data !== undefined) {
                _this.filtros = data;
                _this.totalPages = 0;
                _this.buscarPagina(_this.totalPages);
            }
        });
    };
    ProdespMonitorItensPorProgramaComponent.prototype.buscarPagina = function (totalPages) {
        var _this = this;
        var request = this.montarPesquisa();
        if (request) {
            this.justificativaService.getHttpContext().post("http://localhost:57428/api/itemmonitor/queryitens?TYPE=json", request)
                .map(function (response) {
                var result = response.json();
                if (result.Message === '' || result.Message === null) {
                    if (!result.Data || !result.Data.length) {
                        _this.noDataFound = true;
                        _this.tableData = [];
                        _this.totalPages = 0;
                        _this.monitoramento = null;
                        return;
                    }
                    var itensMonitoramento_1 = [];
                    _this.noDataFound = false;
                    _this.monitoramento = {
                        NomePrograma: result.NomePrograma,
                        DataMonitoramento: result.DataMonitoramento,
                        JustificativasPendentes: result.JustificativasPendentes,
                        QuantidadeAlertasItens: result.QuantidadeAlertasItens,
                        QuantidadeAlertas: result.QuantidadeAlertas,
                        Percentual: result.Percentual,
                        QuantidadeItens: result.QuantidadeItens,
                        TipoConsumoAutonomia: result.TipoConsumoAutonomia,
                        TipoConsumoSaldoZerado: result.TipoConsumoSaldoZerado
                    };
                    result.Data.forEach(function (item) {
                        itensMonitoramento_1.push(new expand_table_data_1.ExpandTableData(item, false, false));
                    });
                    _this.tableData = itensMonitoramento_1;
                    if (totalPages !== undefined) {
                        _this.totalPages = parseInt(result.TotalPages);
                    }
                }
                else {
                    _this.noDataFound = true;
                    _this.tableData = [];
                    _this.totalPages = 0;
                    _this.monitoramento = null;
                    _this.errorMessage = result.Message;
                }
            }).subscribe();
        }
        else {
            this.noDataFound = true;
            this.tableData = [];
            this.totalPages = 0;
            this.monitoramento = null;
            this.errorMessage = 'Selecione um valor para a pesquisa';
        }
    };
    ProdespMonitorItensPorProgramaComponent.prototype.montarPesquisa = function () {
        var _this = this;
        var request = new searchrequest_1.SearchRequest();
        request.OrderBy = 'id_item_programa';
        request.PageNumber = this.page;
        request.RecordsPerPage = this.perPage;
        request.SortDirection = 'asc';
        var props = reflection_1.Reflection.getObjectPropertyNames(this.filtros);
        var possuiJustificativa = props.filter(function (item) {
            if (item.includes('Justificado')) {
                return true;
            }
            return false;
        });
        if (!possuiJustificativa) {
            this.filtroJustificado = null;
        }
        var rules = [];
        var filter = new filter_rule_1.FilterRule();
        props.map(function (item) {
            if (_this.filtros[item] !== null) {
                var tipo = reflection_1.Reflection.getTypeofProperty(_this.filtros, item);
                var rule = new filter_rule_1.FilterRule(item.toString(), _this.filtros[item], 'AND', 'equal', filter.convertType(tipo.toString()));
                rules.push(rule);
            }
        });
        if (rules.length) {
            var rule = new filter_rule_1.FilterRule('FlagAtivo', 'S', 'AND', 'equal', 'string');
            rules.push(rule);
        }
        else {
            return null;
        }
        filter.Rules = rules;
        request.Filter = filter;
        return request;
    };
    ProdespMonitorItensPorProgramaComponent.prototype.rowsSelected = function (event) {
        this.linhasSelecionadas = event;
    };
    ProdespMonitorItensPorProgramaComponent.prototype.pageChanges = function (event) {
        this.page = event;
        this.buscarPagina();
    };
    ProdespMonitorItensPorProgramaComponent.prototype.perPageChanged = function (event) {
        this.page = 1;
        this.perPage = event.perPage;
        this.buscarPagina(this.totalPages);
    };
    return ProdespMonitorItensPorProgramaComponent;
}());
ProdespMonitorItensPorProgramaComponent = __decorate([
    core_1.Component({
        selector: 'prodesp-monitor-itens-por-programa',
        templateUrl: './prodesp-monitor-itens-por-programa.component.html',
        styleUrls: ['./prodesp-monitor-itens-por-programa.component.css']
    }),
    __metadata("design:paramtypes", [ng2_bootstrap_modal_1.DialogService, justificativa_service_1.JustificativaService,
        justificativa_service_1.JustificativaService])
], ProdespMonitorItensPorProgramaComponent);
exports.ProdespMonitorItensPorProgramaComponent = ProdespMonitorItensPorProgramaComponent;
//# sourceMappingURL=prodesp-monitor-itens-por-programa.component.js.map