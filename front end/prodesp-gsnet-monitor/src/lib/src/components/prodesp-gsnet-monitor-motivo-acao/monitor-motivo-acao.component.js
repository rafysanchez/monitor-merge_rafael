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
var prodesp_monitor_modal_confirm_component_1 = require("./../prodesp-monitor-modal-confirm/prodesp-monitor-modal-confirm.component");
var searchrequest_1 = require("./../../models/searchrequest");
var reflection_1 = require("./../../models/reflection");
var pesquisamotivoacao_1 = require("./../../models/pesquisamotivoacao");
var filter_rule_1 = require("./../../models/filter.rule");
var monitor_pesquisa_motivo_acao_component_1 = require("./../prodesp-monitor-pesquisa-motivo-acao/monitor-pesquisa-motivo-acao.component");
var monitor_modal_motivo_acao_component_1 = require("./../prodesp-gsnet-monitor-modal-motivo-acao/monitor-modal-motivo-acao.component");
var http_1 = require("@angular/http");
var motivoacao_service_1 = require("./../../service/motivoacao.service");
var motivo_acao_model_1 = require("./../../models/motivo.acao.model");
var prodesp_ui_1 = require("prodesp-ui");
var core_1 = require("@angular/core");
require("rxjs/add/operator/map");
require("rxjs/add/operator/catch");
require("rxjs/add/observable/throw");
var Rx_1 = require("rxjs/Rx");
var dialog_service_1 = require("ng2-bootstrap-modal/dist/dialog.service");
var ProdespGsnetMonitorMotivoAcaoComponent = (function () {
    function ProdespGsnetMonitorMotivoAcaoComponent(service, dialogService, appConfig) {
        this.service = service;
        this.dialogService = dialogService;
        this.appConfig = appConfig;
        this.page = 1;
        this.perPage = 5;
        this.totalPages = 1;
        this.filtros = new pesquisamotivoacao_1.PesquisaMotivoAcao();
    }
    ProdespGsnetMonitorMotivoAcaoComponent.prototype.ngOnInit = function () {
        this.tableConfig = new prodesp_ui_1.TableOptions();
        this.tableConfig.showPerPage = [5, 10, 15, 30, 50, 100];
        this.tableConfig.tableHeader = 'Motivos/Ações';
        this.tableConfig.columnsDefinition = [
            new prodesp_ui_1.TableColumnDefinition('Tipo', 'Tipo'),
            new prodesp_ui_1.TableColumnDefinition('Nome', 'Motivo/Ação'),
            new prodesp_ui_1.TableColumnDefinition('Descricao', 'Descrição'),
            new prodesp_ui_1.TableColumnDefinition('JustificativaObrigatoria', 'Justif. Obrg.'),
            new prodesp_ui_1.TableColumnDefinition('PodeEditarJustificativa', 'Pode Editar Justif.'),
            new prodesp_ui_1.TableColumnDefinition('FlagAtivo', 'Status'),
            new prodesp_ui_1.TableColumnDefinition('', 'Ações')
        ];
        this.sortDirection = this.tableConfig.sortDirection = 'asc';
        this.sortBy = this.tableConfig.sortBy = 'Nome';
        this.buscarPagina(true);
    };
    ProdespGsnetMonitorMotivoAcaoComponent.prototype.initTableData = function () {
        var _this = this;
        this.service.buscarTodos().map(function (resp) {
            _this.tableData = resp;
            console.log(_this.tableData);
        }).subscribe();
    };
    ProdespGsnetMonitorMotivoAcaoComponent.prototype.onAdd = function () {
        var _this = this;
        this.dialogService.addDialog(monitor_modal_motivo_acao_component_1.ProdespGsnetMonitorModalMotivoAcaoComponent, {
            title: 'Adicionar Motivo/Ação',
            closeButtonText: 'Fechar',
            confirmButtonText: 'Salvar',
            showConfirmButton: true,
            isClickDisabled: true,
            novoMotivoAcao: new motivo_acao_model_1.MotivoAcao()
        }).subscribe(function (result) {
            if (result) {
                _this.service.inserir(result).map(function (response) {
                    _this.initTableData();
                    _this.abrirMensagemSucesso('Item atualizado com sucesso');
                }).catch(function (error) { return _this.tratarErro(error); }).subscribe();
            }
        });
    };
    ProdespGsnetMonitorMotivoAcaoComponent.prototype.onSortClicked = function (event) {
        this.page = 1;
        this.sortBy = event.column.SortColumnId;
        this.sortDirection = event.sortDirection;
        this.buscarPagina(false);
    };
    ProdespGsnetMonitorMotivoAcaoComponent.prototype.onSearch = function () {
        var _this = this;
        this.dialogService.addDialog(monitor_pesquisa_motivo_acao_component_1.ProdespMonitorPesquisaMotivoAcaoComponent, {
            title: 'Pesquisar Motivo/Ação',
            closeButtonText: 'Fechar',
            confirmButtonText: 'Pesquisar',
            showConfirmButton: true,
            filtros: this.filtros
        }).subscribe(function (result) {
            if (result) {
                _this.page = 1;
                _this.buscarPagina(true);
            }
        });
    };
    ProdespGsnetMonitorMotivoAcaoComponent.prototype.buscarPagina = function (resetTotalPages) {
        var _this = this;
        this.isLoading = true;
        var request = this.montarPesquisa();
        this.service.getHttpContext().post(this.appConfig.getConfig('host') + "api/motivoacao/queryitens?TYPE=json", request).map(function (response) {
            _this.isLoading = false;
            var data = response.json();
            _this.tableData = data.Itens;
            if (resetTotalPages) {
                _this.totalPages = data.TotalPages;
            }
        }).catch(function (error) { return _this.tratarErro(error); }).subscribe();
    };
    ProdespGsnetMonitorMotivoAcaoComponent.prototype.montarPesquisa = function () {
        var _this = this;
        var request = new searchrequest_1.SearchRequest();
        request.OrderBy = this.sortBy;
        request.PageNumber = this.page;
        request.RecordsPerPage = this.perPage;
        request.SortDirection = this.sortDirection;
        var props = reflection_1.Reflection.getObjectPropertyNames(this.filtros);
        var rules = [];
        var filter = new filter_rule_1.FilterRule();
        props.map(function (item) {
            if (_this.filtros[item] !== null && _this.filtros[item].toString() !== '-1') {
                var tipo = reflection_1.Reflection.getTypeofProperty(_this.filtros, item);
                var rule = new filter_rule_1.FilterRule(item.toString(), _this.filtros[item], 'AND', 'equal', filter.convertType(tipo.toString()));
                rules.push(rule);
            }
        });
        filter.Rules = rules;
        request.Filter = filter;
        return request;
    };
    ProdespGsnetMonitorMotivoAcaoComponent.prototype.onEdit = function (item) {
        var _this = this;
        this.service.buscarPorId("/" + item.Id.toString()).map(function (motivoAcao) {
            _this.dialogService.addDialog(monitor_modal_motivo_acao_component_1.ProdespGsnetMonitorModalMotivoAcaoComponent, {
                title: 'Editar Motivo/Ação',
                closeButtonText: 'Fechar',
                confirmButtonText: 'Salvar',
                showConfirmButton: true,
                isClickDisabled: true,
                editMode: true,
                modalData: motivoAcao,
                novoMotivoAcao: motivoAcao
            }).subscribe((function (result) {
                if (result) {
                    _this.service.atualizar(result).map(function (response) {
                        _this.initTableData();
                        _this.abrirMensagemSucesso('Item atualizado com sucesso');
                    }).catch(function (error) { return _this.tratarErro(error); }).subscribe();
                }
            }));
        }).subscribe();
    };
    ProdespGsnetMonitorMotivoAcaoComponent.prototype.tratarErro = function (error) {
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
    ProdespGsnetMonitorMotivoAcaoComponent.prototype.abrirMensagemSucesso = function (msg) {
        var _this = this;
        this.dialogService.addDialog(prodesp_monitor_modal_confirm_component_1.ProdespMonitorModalConfirmComponent, {
            title: 'Solicitação efetivada com sucesso',
            text: msg,
            closeButtonText: 'Fechar',
            confirmButtonText: 'Utilizar',
            showConfirmButton: false
        }).subscribe(function (result) {
            _this.page = 1;
            _this.buscarPagina();
        });
    };
    ProdespGsnetMonitorMotivoAcaoComponent.prototype.decodeSituacao = function (item) {
        return item.Situacao ? 'Ativo' : 'Inativo';
    };
    ProdespGsnetMonitorMotivoAcaoComponent.prototype.decodeJustificativaObrigatoria = function (item) {
        return item.JustificativaObrigatoria ? 'Sim' : 'Não';
    };
    ProdespGsnetMonitorMotivoAcaoComponent.prototype.decodePodeEditarJustificativa = function (item) {
        return item.PodeEditarJustificativa ? 'Sim' : 'Não';
    };
    ProdespGsnetMonitorMotivoAcaoComponent.prototype.abrirPesquisa = function () { };
    ProdespGsnetMonitorMotivoAcaoComponent.prototype.pageChanges = function (value) {
        debugger;
        this.page = value;
        this.buscarPagina();
    };
    ProdespGsnetMonitorMotivoAcaoComponent.prototype.perPageChanged = function (value) {
        this.page = 1;
        this.perPage = value.perPage;
        this.buscarPagina(true);
    };
    return ProdespGsnetMonitorMotivoAcaoComponent;
}());
ProdespGsnetMonitorMotivoAcaoComponent = __decorate([
    core_1.Component({
        selector: 'prodesp-gsnet-monitor-motivo-acao',
        templateUrl: './monitor-motivo-acao.component.html',
        styleUrls: ['./monitor-motivo-acao.component.css']
    }),
    __metadata("design:paramtypes", [motivoacao_service_1.MotivoAcaoService, dialog_service_1.DialogService, config_service_1.AppConfig])
], ProdespGsnetMonitorMotivoAcaoComponent);
exports.ProdespGsnetMonitorMotivoAcaoComponent = ProdespGsnetMonitorMotivoAcaoComponent;
//# sourceMappingURL=monitor-motivo-acao.component.js.map