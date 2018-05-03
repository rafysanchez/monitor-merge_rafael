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
var motivo_acao_model_1 = require("./../../models/motivo.acao.model");
var acao_1 = require("./../../models/acao");
var Rx_1 = require("rxjs/Rx");
var expand_table_data_1 = require("../../models/expand.table.data");
var fluxo_justicacao_1 = require("../../models/fluxo.justicacao");
var filter_rule_1 = require("./../../models/filter.rule");
var reflection_1 = require("./../../models/reflection");
var searchrequest_1 = require("./../../models/searchrequest");
var justificativa_service_1 = require("../../service/justificativa.service");
var prodesp_monitor_modal_confirm_component_1 = require("./../prodesp-monitor-modal-confirm/prodesp-monitor-modal-confirm.component");
var motivo_1 = require("./../../models/motivo");
var pesquisa_medicamento_component_1 = require("./../prodesp-monitor-modal-pesquisa-medicamento/pesquisa-medicamento.component");
var ng2_bootstrap_modal_1 = require("ng2-bootstrap-modal");
var core_1 = require("@angular/core");
var nova_justificativa_component_1 = require("../prodesp-monitor-modal-nova-justificativa/nova-justificativa.component");
var pesquisa_medicamento_model_1 = require("../../models/pesquisa.medicamento.model");
var prodesp_ui_1 = require("prodesp-ui");
var http_1 = require("@angular/http");
var ProdespMonitorJustificativaComponent = (function () {
    function ProdespMonitorJustificativaComponent(appConfig, dialogService, justificativaService, service) {
        this.appConfig = appConfig;
        this.dialogService = dialogService;
        this.justificativaService = justificativaService;
        this.service = service;
        this.linhasSelecionadas = [];
        this.tableData = [];
        this.showPerPage = [5, 10, 15, 20];
        this.perPage = 5;
        this.page = 1;
        this.expandMode = 'Expandir Todos';
        this.expandAll = false;
        this.idJustificador = appConfig.getConfig('IdJustificador');
    }
    ProdespMonitorJustificativaComponent.prototype.ngOnInit = function () {
        this.showSearchTextBox = false;
        this.filtros = new pesquisa_medicamento_model_1.PesquisaMedicamento();
        this.initTableOptions();
        this.sortDirection = this.tableOptions.sortDirection;
        this.sortBy = this.tableOptions.sortBy;
    };
    ProdespMonitorJustificativaComponent.prototype.toogleExpand = function () {
        this.expandAll = !this.expandAll;
        if (this.expandAll) {
            this.expandMode = 'Recolher Todos';
        }
        else {
            this.expandMode = 'Expandir Todos';
        }
    };
    ProdespMonitorJustificativaComponent.prototype.abrirPesquisa = function () {
        var _this = this;
        this.dialogService.addDialog(pesquisa_medicamento_component_1.ProdespMonitorModalPesquisaMedicamentoComponent, {
            title: 'Pesquisar Medicamentos',
            closeButtonText: 'Fechar',
            confirmButtonText: 'Pesquisar',
            showConfirmButton: true,
            justificador: this.idJustificador,
            filtros: this.filtros,
            isClickDisabled: false,
        }).subscribe(function (data) {
            if (data !== undefined) {
                _this.filtros = data;
                _this.totalPages = 0;
                _this.page = 1;
                _this.buscarPagina(true);
            }
        });
    };
    ProdespMonitorJustificativaComponent.prototype.buscarPagina = function (resetPageNumber) {
        var _this = this;
        this.isLoading = true;
        var request = this.montarPesquisa();
        if (request) {
            this.justificativaService.getHttpContext().post(this.appConfig.getConfig('host') + "api/itemmonitor/queryitens?TYPE=json", request)
                .map(function (response) {
                _this.isLoading = false;
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
                        TipoConsumoSaldoZerado: result.TipoConsumoSaldoZerado,
                        IdPrograma: result.IdPrograma
                    };
                    result.Data.forEach(function (item) {
                        item.FluxoJustificacao = new fluxo_justicacao_1.FluxoJustificacao(item.JustificadoFME, item.JustificadoCAF, item.JustificadoCMP, item.CAFPublica);
                        itensMonitoramento_1.push(new expand_table_data_1.ExpandTableData(item, false, false));
                    });
                    _this.tableData = itensMonitoramento_1;
                    if (resetPageNumber) {
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
            }).catch(function (error) { return _this.tratarErro(error); }).subscribe();
        }
        else {
            this.noDataFound = true;
            this.tableData = [];
            this.totalPages = 0;
            this.monitoramento = null;
            this.errorMessage = 'Selecione um valor para a pesquisa';
        }
    };
    ProdespMonitorJustificativaComponent.prototype.onSortClicked = function (event) {
        this.page = 1;
        this.sortBy = event.column.SortColumnId;
        this.sortDirection = event.sortDirection;
        this.buscarPagina(true);
    };
    ProdespMonitorJustificativaComponent.prototype.montarPesquisa = function () {
        var _this = this;
        var request = new searchrequest_1.SearchRequest();
        request.OrderBy = this.sortBy;
        request.PageNumber = this.page;
        request.RecordsPerPage = this.perPage;
        request.SortDirection = this.sortDirection;
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
    ProdespMonitorJustificativaComponent.prototype.rowsSelected = function (event) {
        this.linhasSelecionadas = event;
    };
    ProdespMonitorJustificativaComponent.prototype.pageChanges = function (event) {
        this.page = event;
        this.buscarPagina(false);
    };
    ProdespMonitorJustificativaComponent.prototype.perPageChanged = function (event) {
        this.page = 1;
        this.perPage = event.perPage;
        this.buscarPagina(true);
    };
    ProdespMonitorJustificativaComponent.prototype.abrirJustificarPorPrograma = function () {
        var _this = this;
        var data = this.comporDadosModalJustificativa('Justificar Itens por Programa');
        this.dialogService.addDialog(nova_justificativa_component_1.ProdespMonitorModalNovaJustificativaComponent, data).subscribe(function (novaJustificativa) {
            if (novaJustificativa) {
                _this.isLoading = true;
                var dataToPost = novaJustificativa;
                dataToPost.Itens = _this.linhasSelecionadas.map(function (item) {
                    return {
                        IdItemMonitoramento: item.data.Id,
                        IdItemGsnet: item.data.IdItemGsnet,
                        IdGestorMonitor: item.data.IdGestorMonitor
                    };
                });
                dataToPost.Data = {
                    IdJustificador: _this.idJustificador,
                    IdPrograma: _this.monitoramento.IdPrograma,
                    Acao: new motivo_acao_model_1.MotivoAcao(novaJustificativa.IdAcao, novaJustificativa.AcaoJustificativa),
                    Motivo: new motivo_acao_model_1.MotivoAcao(novaJustificativa.IdMotivo, novaJustificativa.MotivoJustificativa)
                };
                _this.justificativaService.justificarPorPrograma(dataToPost).map(function (response) {
                    _this.isLoading = false;
                    _this.abrirMensagemSucesso('Os itens selecionados foram justificados com sucesso');
                }).catch(function (error) { return _this.tratarErro(error); }).subscribe();
            }
        });
    };
    ProdespMonitorJustificativaComponent.prototype.abrirNovaJustificativa = function () {
        var config = this.comporDadosModalJustificativa('Justificar itens selecionados');
        this.abrirModalJustificativa(config);
    };
    ProdespMonitorJustificativaComponent.prototype.excluirJustificativas = function () {
        var _this = this;
        this.dialogService.addDialog(prodesp_monitor_modal_confirm_component_1.ProdespMonitorModalConfirmComponent, {
            title: 'Excluir Justificativas selecionadas',
            text: 'Tem certeza que deseja excluir as justificativas para os medicamentos selecionados? Essa operação não poderá ser desfeita',
            closeButtonText: 'Fechar',
            confirmButtonText: 'Excluir',
            showConfirmButton: true
        }).subscribe(function (confirmed) {
            if (confirmed) {
                _this.isLoading = true;
                var dataToPost = {};
                dataToPost.Itens = _this.linhasSelecionadas.map(function (item) {
                    return {
                        IdItemMonitoramento: item.data.Id,
                        IdItemGsnet: item.data.IdItemGsnet,
                        IdGestorMonitor: item.data.IdGestorMonitor
                    };
                });
                dataToPost.IdJustificador = _this.idJustificador;
                _this.justificativaService.deletarVarios(dataToPost).map(function (result) {
                    _this.isLoading = false;
                    _this.abrirMensagemSucesso('Justificativas excluídas com sucesso');
                }).catch(function (error) { return _this.tratarErro(error); }).subscribe();
            }
        });
    };
    ProdespMonitorJustificativaComponent.prototype.abrirMensagemSucesso = function (msg) {
        var _this = this;
        this.expandAll = false;
        this.dialogService.addDialog(prodesp_monitor_modal_confirm_component_1.ProdespMonitorModalConfirmComponent, {
            title: 'Solicitação efetivada com sucesso',
            text: msg,
            closeButtonText: 'Fechar',
            confirmButtonText: 'Utilizar',
            showConfirmButton: false
        }).subscribe(function (result) {
            _this.page = 1;
            _this.buscarPagina(false);
        });
    };
    ProdespMonitorJustificativaComponent.prototype.abrirJustificativaAnterior = function () {
        var _this = this;
        this.dialogService.addDialog(prodesp_monitor_modal_confirm_component_1.ProdespMonitorModalConfirmComponent, {
            title: 'Utilizar justificativa anterior',
            text: 'Deseja usar a justificativa anterior desses medicamentos ?',
            closeButtonText: 'Fechar',
            confirmButtonText: 'Utilizar',
            showConfirmButton: true
        }).subscribe(function (data) {
            if (data) {
                _this.isLoading = true;
                var dataToPost = {};
                dataToPost.Itens = _this.linhasSelecionadas.map(function (item) {
                    return {
                        IdItemMonitoramento: item.data.Id,
                        IdItemGsnet: item.data.IdItemGsnet,
                        IdGestorMonitor: item.data.IdGestorMonitor
                    };
                });
                dataToPost.IdJustificador = _this.idJustificador;
                _this.justificativaService.usarJustificativaAnterior(dataToPost).map(function (response) {
                    _this.isLoading = false;
                    _this.abrirMensagemSucesso('Os itens selecionados foram justificados com sucesso');
                }).catch(function (error) { return _this.tratarErro(error); }).subscribe();
            }
        });
    };
    ProdespMonitorJustificativaComponent.prototype.comporDadosModalJustificativa = function (title) {
        return {
            title: title,
            closeButtonText: 'Fechar',
            confirmButtonText: 'Salvar',
            showConfirmButton: true,
            acao: new acao_1.Acao(),
            motivo: new motivo_1.Motivo()
        };
    };
    ProdespMonitorJustificativaComponent.prototype.abrirModalJustificativa = function (data) {
        var _this = this;
        this.dialogService.addDialog(nova_justificativa_component_1.ProdespMonitorModalNovaJustificativaComponent, data).subscribe(function (novaJustificativa) {
            if (novaJustificativa) {
                _this.isLoading = true;
                var dataToPost = novaJustificativa;
                dataToPost.Itens = _this.linhasSelecionadas.map(function (item) {
                    return {
                        IdItemMonitoramento: item.data.Id,
                        IdItemGsnet: item.data.IdItemGsnet,
                        IdGestorMonitor: item.data.IdGestorMonitor
                    };
                });
                dataToPost.IdJustificador = _this.idJustificador;
                _this.justificativaService.justificarVarios(dataToPost).map(function (response) {
                    _this.isLoading = false;
                    _this.abrirMensagemSucesso('Os itens selecionados foram justificados com sucesso');
                }).catch(function (error) { return _this.tratarErro(error); }).subscribe();
            }
        });
    };
    ProdespMonitorJustificativaComponent.prototype.initTableOptions = function () {
        this.tableOptions = new prodesp_ui_1.TableOptions();
        this.tableOptions.showPerPage = [5, 10, 15, 30, 50, 100, 200];
        this.tableOptions.tableHeader = 'Alertas Gerados';
        this.tableOptions.sortBy = 'Nome';
        this.tableOptions.sortDirection = 'asc';
        this.tableOptions.columnsDefinition = [
            new prodesp_ui_1.TableColumnDefinition('GrupoRecursos', 'Grupo de Recursos'),
            new prodesp_ui_1.TableColumnDefinition('Local', 'Local'),
            new prodesp_ui_1.TableColumnDefinition('IdItemGsnet', 'Código'),
            new prodesp_ui_1.TableColumnDefinition('Nome', 'Item'),
            new prodesp_ui_1.TableColumnDefinition('UnidadeDistribuicao', 'Unidade de Distribuicao'),
            new prodesp_ui_1.TableColumnDefinition('QuantidadeSaldoDisponivel', 'Saldo Disponível'),
            new prodesp_ui_1.TableColumnDefinition('QuantidadeDiasAutonomia', 'Autonomia(Dias)'),
            new prodesp_ui_1.TableColumnDefinition('DataUltimaFatura', 'Dt. Ultima Fatura'),
            new prodesp_ui_1.TableColumnDefinition('QuantidadeUltimaFatura', 'Qt. Última Fatura'),
            new prodesp_ui_1.TableColumnDefinition('DataUltimoEmpenho', 'Dt. Ultimo Empenho'),
            new prodesp_ui_1.TableColumnDefinition('QuantidadeUltimoEmpenho', 'Qt. Ultimo Empenho'),
            new prodesp_ui_1.TableColumnDefinition('QuantidadeConsumo', 'Consumo'),
            new prodesp_ui_1.TableColumnDefinition('DataUltimoConsumo', 'Dt. Ultimo Consumo'),
            new prodesp_ui_1.TableColumnDefinition('QuantidadeUltimoConsumo', 'Qt. Ultimo Consumo'),
            new prodesp_ui_1.TableColumnDefinition('', 'Justificativas'),
            new prodesp_ui_1.TableColumnDefinition('', 'Ações')
        ];
    };
    ProdespMonitorJustificativaComponent.prototype.tratarErro = function (error) {
        this.isLoading = false;
        var errMsg;
        if (!errMsg && error instanceof http_1.Response) {
            var exception = JSON.stringify(error) || '';
            var e = JSON.parse(exception);
            errMsg = e._body;
        }
        if (errMsg) {
            this.dialogService.addDialog(prodesp_monitor_modal_confirm_component_1.ProdespMonitorModalConfirmComponent, {
                title: 'Erro na solicitação',
                text: errMsg,
                closeButtonText: 'Fechar',
                confirmButtonText: 'Utilizar',
                showConfirmButton: false
            }).subscribe(function (data) { });
        }
        return Rx_1.Observable.throw(error);
    };
    return ProdespMonitorJustificativaComponent;
}());
ProdespMonitorJustificativaComponent = __decorate([
    core_1.Component({
        selector: 'prodesp-monitor-justificativa',
        templateUrl: './prodesp-monitor-justificativa.component.html',
        styleUrls: ['./prodesp-monitor-justificativa.component.css']
    }),
    __metadata("design:paramtypes", [config_service_1.AppConfig, ng2_bootstrap_modal_1.DialogService, justificativa_service_1.JustificativaService, justificativa_service_1.JustificativaService])
], ProdespMonitorJustificativaComponent);
exports.ProdespMonitorJustificativaComponent = ProdespMonitorJustificativaComponent;
//# sourceMappingURL=prodesp-monitor-justificativa.component.js.map