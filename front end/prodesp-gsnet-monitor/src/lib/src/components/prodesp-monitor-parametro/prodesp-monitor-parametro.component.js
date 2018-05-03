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
var config_service_1 = require("../../service/config.service");
var core_1 = require("@angular/core");
var prodesp_ui_1 = require("prodesp-ui");
require("rxjs/add/operator/map");
require("rxjs/add/operator/catch");
require("rxjs/add/observable/throw");
var Rx_1 = require("rxjs/Rx");
var dialog_service_1 = require("ng2-bootstrap-modal/dist/dialog.service");
var parametro_service_1 = require("./../../service/parametro.service");
var searchrequest_1 = require("./../../models/searchrequest");
var reflection_1 = require("./../../models/reflection");
var filter_rule_1 = require("./../../models/filter.rule");
var PesquisaRegraMotor_1 = require("./../../models/PesquisaRegraMotor");
var prodesp_monitor_modal_parametro_component_1 = require("../prodesp-monitor-modal-parametro/prodesp-monitor-modal-parametro.component");
var parametro_1 = require("./../../models/parametro");
var tipoparametro_1 = require("./../../models/tipoparametro");
var ProdespMonitorParametroComponent = (function () {
    function ProdespMonitorParametroComponent(dialogService, service, appConfig) {
        this.dialogService = dialogService;
        this.service = service;
        this.appConfig = appConfig;
        this.page = 1;
        this.perPage = 5;
        this.totalPages = 1;
        this.filtros = new PesquisaRegraMotor_1.PesquisaRegraMotor();
        this.parametros = [];
    }
    ProdespMonitorParametroComponent.prototype.ngOnInit = function () {
        this.selectedTipo = 0;
        this.tableConfig = new prodesp_ui_1.TableOptions();
        this.tableConfig.showPerPage = [5, 15, 20, 100, 200, 300];
        this.tableConfig.tableHeader = 'Parâmetro';
        this.tableConfig.columnsDefinition = [
            new prodesp_ui_1.TableColumnDefinition('', 'Programa'),
            new prodesp_ui_1.TableColumnDefinition('', 'Tipo'),
            new prodesp_ui_1.TableColumnDefinition('', 'Vigência'),
            new prodesp_ui_1.TableColumnDefinition('', 'Status'),
            new prodesp_ui_1.TableColumnDefinition('', 'Ações')
        ];
        this.Tipos = [
            new tipoparametro_1.TipoParametro(1, '1', 'Autonomia Consumo'),
            new tipoparametro_1.TipoParametro(2, '2', 'Saldo Zerado')
        ];
        this.comboData = this.Tipos;
        this.buscarPagina(this.totalPages);
        this.carregaComboTipos();
    };
    ProdespMonitorParametroComponent.prototype.initTableData = function () {
        var _this = this;
        this.service
            .buscarTodos()
            .map(function (resp) {
            _this.tableData = resp;
        })
            .subscribe();
    };
    ProdespMonitorParametroComponent.prototype.carregaComboTipos = function () {
    };
    ProdespMonitorParametroComponent.prototype.onSelect = function (Id) {
        this.selectedTipo = Id;
        console.log(this.selectedTipo);
    };
    ProdespMonitorParametroComponent.prototype.onAdd = function (tipo) {
        var _this = this;
        var novoPrograma = new parametro_1.Parametro();
        novoPrograma.Tipo = this.selectedTipo;
        if (tipo > 0) {
            console.log('tipo: ' + tipo);
            this.dialogService
                .addDialog(prodesp_monitor_modal_parametro_component_1.ProdespMonitorModalParametroComponent, {
                title: novoPrograma.Tipo == 1
                    ? 'Cadastro - Autonomia Consumo'
                    : 'Cadastro Saldo Zerado',
                closeButtonText: 'Fechar',
                confirmButtonText: 'Salvar',
                showConfirmButton: true,
                isClickDisabled: true,
                editMode: false,
                tipoPrograma: this.selectedTipo,
                novoParametro: novoPrograma
            })
                .subscribe(function (result) {
                if (result) {
                    _this.service
                        .Cadastrar(result)
                        .map(function (response) {
                        alert('ok');
                    })
                        .catch(function (error) {
                        alert('deu erro');
                        return Rx_1.Observable.throw(error);
                    })
                        .subscribe();
                }
            });
        }
    };
    ProdespMonitorParametroComponent.prototype.onEdit = function (item) {
        var _this = this;
        this.service.CarregarPorID("/" + item.IdRegraMotor.toString())
            .map(function (response) {
            _this.dialogService
                .addDialog(prodesp_monitor_modal_parametro_component_1.ProdespMonitorModalParametroComponent, {
                title: 'Editar Parâmetros Autonomia - Consumo',
                closeButtonText: 'Fechar',
                confirmButtonText: 'Salvar',
                showConfirmButton: true,
                isClickDisabled: true,
                editMode: true,
                tipoPrograma: _this.selectedTipo,
                novoParametro: response.json()
            })
                .subscribe(function (result) {
                if (result) {
                    _this.service
                        .Editar(result)
                        .map(function (response) {
                        alert('ok');
                    })
                        .catch(function (error) {
                        alert('deu erro');
                        return Rx_1.Observable.throw(error);
                    })
                        .subscribe();
                }
            });
        })
            .subscribe();
    };
    ProdespMonitorParametroComponent.prototype.buscarPagina = function (totalPages) {
        var _this = this;
        var request = this.montarPesquisa();
        this.service
            .getHttpContext()
            .post(this.appConfig.getConfig('host') + "api/regramotor/queryitens", request)
            .map(function (response) {
            var data = response.json();
            _this.tableData = data.Itens;
            if (totalPages) {
                _this.totalPages = data.TotalPages;
            }
        })
            .subscribe();
    };
    ProdespMonitorParametroComponent.prototype.montarPesquisa = function () {
        var _this = this;
        var request = new searchrequest_1.SearchRequest();
        request.OrderBy = 'IdRegraMotor';
        request.PageNumber = this.page;
        request.RecordsPerPage = this.perPage;
        request.SortDirection = 'asc';
        var props = reflection_1.Reflection.getObjectPropertyNames(this.filtros);
        var rules = [];
        var filter = new filter_rule_1.FilterRule();
        props.map(function (item) {
            if (_this.filtros[item] !== null || _this.filtros[item] === -1) {
                var tipo = reflection_1.Reflection.getTypeofProperty(_this.filtros, item);
                var rule_1 = new filter_rule_1.FilterRule(item.toString(), _this.filtros[item], 'AND', 'equal', filter.convertType(tipo.toString()));
                rules.push(rule_1);
            }
        });
        var rule = new filter_rule_1.FilterRule('FlagAtivo', 'S', 'AND', 'equal', 'string');
        rules.push(rule);
        filter.Rules = rules;
        request.Filter = filter;
        return request;
    };
    ProdespMonitorParametroComponent.prototype.decodeSituacao = function (item) {
        return item.FlagAtivo ? 'Ativo' : 'Inativo';
    };
    ProdespMonitorParametroComponent.prototype.decodeTipo = function (item) {
        return item.Tipo ? 'Ativo' : 'Inativo';
    };
    ProdespMonitorParametroComponent.prototype.pageChanges = function (value) {
        this.page = value;
        this.buscarPagina();
    };
    ProdespMonitorParametroComponent.prototype.perPageChanged = function (value) {
        this.page = 1;
        this.perPage = value;
        this.buscarPagina();
    };
    ProdespMonitorParametroComponent.prototype.onSearch = function () {
    };
    return ProdespMonitorParametroComponent;
}());
ProdespMonitorParametroComponent = __decorate([
    core_1.Component({
        selector: 'prodesp-monitor-parametro',
        templateUrl: './prodesp-monitor-parametro.component.html',
        styleUrls: ['./prodesp-monitor-parametro.component.css']
    }),
    __metadata("design:paramtypes", [dialog_service_1.DialogService,
        parametro_service_1.ParametroService,
        config_service_1.AppConfig])
], ProdespMonitorParametroComponent);
exports.ProdespMonitorParametroComponent = ProdespMonitorParametroComponent;
//# sourceMappingURL=prodesp-monitor-parametro.component.js.map