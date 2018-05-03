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
        this.onSortClicked = new core_1.EventEmitter();
    }
    ProdespExpandableTable.prototype.ngOnInit = function () {
        console.log(this.tableData);
        this.carregarDropDownAcao();
        this.carregarDropDownMotivo();
        this.sortDirection = this.tableOptions.sortDirection;
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
        this.selecteds = selecteds.length;
        this.onRowsSelected.emit(selecteds);
    };
    ProdespExpandableTable.prototype.checkIfAllSelected = function () {
        this.selectedAll = this.tableData.every(function (item) {
            return item.selected === true;
        });
        var selecteds = this.obterSelecionados();
        this.selecteds = selecteds.length;
        this.onRowsSelected.emit(selecteds);
    };
    ProdespExpandableTable.prototype.isSorting = function (name) {
        return this.tableOptions.sortBy !== name && name !== '';
    };
    ;
    ProdespExpandableTable.prototype.isSortAsc = function (name) {
        var isSortAsc = this.tableOptions.sortBy === name && this.sortDirection === 'asc';
        return isSortAsc;
    };
    ;
    ProdespExpandableTable.prototype.isSortDesc = function (name) {
        var isSortDesc = this.tableOptions.sortBy === name && this.sortDirection === 'desc';
        return isSortDesc;
    };
    ;
    ProdespExpandableTable.prototype.sortHeaderClick = function (headerName) {
        var _this = this;
        if (headerName) {
            if (this.tableOptions.sortBy === headerName) {
                this.sortDirection = this.sortDirection === 'asc' ? 'desc' : 'asc';
            }
            else {
                this.sortDirection = this.tableOptions.sortDirection;
            }
            this.tableOptions.sortBy = headerName;
            var column = this.tableOptions
                .columnsDefinition
                .filter(function (c) { return c.SortColumnId === _this.tableOptions.sortBy; })[0];
            this.onSortClicked.emit({ column: column, sortDirection: this.sortDirection });
        }
    };
    ProdespExpandableTable.prototype.toggleExpand = function (row) {
        row.expanded = !row.expanded;
    };
    ProdespExpandableTable.prototype.viewHistorico = function (row) {
        this.dialogService.addDialog(prodesp_monitor_modal_historico_component_1.ProdespMonitorModalHistoricoComponent, {
            title: "Hist\u00F3rico de Justificativas - " + row.data.Nome + " - " + row.data.Local + " ",
            showConfirmButton: false,
            closeButtonText: 'Fechar',
            idItemGsNet: row.data.IdItemGsnet,
            idPrograma: row.data.IdPrograma,
            idGestor: row.data.IdGestorMonitor
        });
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
    __metadata("design:type", prodesp_ui_1.TableOptions)
], ProdespExpandableTable.prototype, "tableOptions", void 0);
__decorate([
    core_1.Output(),
    __metadata("design:type", core_1.EventEmitter)
], ProdespExpandableTable.prototype, "onRowsSelected", void 0);
__decorate([
    core_1.Output(),
    __metadata("design:type", core_1.EventEmitter)
], ProdespExpandableTable.prototype, "onPageChanges", void 0);
__decorate([
    core_1.Output(),
    __metadata("design:type", core_1.EventEmitter)
], ProdespExpandableTable.prototype, "onSortClicked", void 0);
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