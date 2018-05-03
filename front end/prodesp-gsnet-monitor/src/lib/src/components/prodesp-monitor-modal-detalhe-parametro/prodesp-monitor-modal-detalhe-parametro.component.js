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
var core_1 = require("@angular/core");
var modal_component_model_1 = require("../../models/modal.component.model");
var dialog_service_1 = require("ng2-bootstrap-modal/dist/dialog.service");
var prodesp_ui_1 = require("prodesp-ui");
var searchrequest_1 = require("./../../models/searchrequest");
require("rxjs/add/operator/map");
require("rxjs/add/operator/catch");
require("rxjs/add/observable/throw");
var reflection_1 = require("./../../models/reflection");
var parametro_service_1 = require("../../service/parametro.service");
var filter_rule_1 = require("./../../models/filter.rule");
var pesquisamotivoacao_1 = require("./../../models/pesquisamotivoacao");
var ProdespMonitorModalDetalheParametroComponent = (function (_super) {
    __extends(ProdespMonitorModalDetalheParametroComponent, _super);
    function ProdespMonitorModalDetalheParametroComponent(service, dialogService) {
        var _this = _super.call(this, dialogService) || this;
        _this.service = service;
        _this.page = 1;
        _this.perPage = 5;
        _this.totalPages = 1;
        _this.filtros = new pesquisamotivoacao_1.PesquisaMotivoAcao();
        _this.idRegraMotor = 0;
        return _this;
    }
    ProdespMonitorModalDetalheParametroComponent.prototype.ngOnInit = function () {
        this.tableConfig = new prodesp_ui_1.TableOptions();
        this.tableConfig.showPerPage = [5, 10, 15, 30, 50, 100];
        this.tableConfig.tableHeader = 'Detalhes - Autonomia Consumo';
        this.tableConfig.columnsDefinition = [
            new prodesp_ui_1.TableColumnDefinition('', 'Nome do Parâmetro'),
            new prodesp_ui_1.TableColumnDefinition('', 'Valor do Parâmetro')
        ];
        this.buscarDados(this.idRegraMotor);
    };
    ProdespMonitorModalDetalheParametroComponent.prototype.ngOnChanges = function (changes) {
    };
    ProdespMonitorModalDetalheParametroComponent.prototype.buscarDados = function (Id) {
        var _this = this;
        this.service.getHttpContext().get("http://localhost:57428/api/parametrovalor/retDadosViewDetalheConsumo/" + Id).map(function (response) {
            var data = response.json();
            _this.tableData = data;
        }).subscribe();
    };
    ProdespMonitorModalDetalheParametroComponent.prototype.montarPesquisa = function () {
        var _this = this;
        var request = new searchrequest_1.SearchRequest();
        request.OrderBy = 'Nome';
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
    ProdespMonitorModalDetalheParametroComponent.prototype.onSearch = function () {
    };
    ProdespMonitorModalDetalheParametroComponent.prototype.perPageChanged = function (value) {
        this.page = 1;
        this.perPage = value;
        this.buscarDados();
    };
    return ProdespMonitorModalDetalheParametroComponent;
}(modal_component_model_1.ModalComponent));
ProdespMonitorModalDetalheParametroComponent = __decorate([
    core_1.Component({
        selector: 'app-prodesp-monitor-modal-detalhe-parametro',
        templateUrl: './prodesp-monitor-modal-detalhe-parametro.component.html',
        styleUrls: ['./prodesp-monitor-modal-detalhe-parametro.component.css']
    }),
    __metadata("design:paramtypes", [parametro_service_1.ParametroService, dialog_service_1.DialogService])
], ProdespMonitorModalDetalheParametroComponent);
exports.ProdespMonitorModalDetalheParametroComponent = ProdespMonitorModalDetalheParametroComponent;
//# sourceMappingURL=prodesp-monitor-modal-detalhe-parametro.component.js.map