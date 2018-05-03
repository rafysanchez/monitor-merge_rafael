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
var Observable_1 = require("rxjs/Observable");
var ng2_bootstrap_modal_1 = require("ng2-bootstrap-modal");
var prodesp_monitor_modal_confirm_component_1 = require("./../prodesp-monitor-modal-confirm/prodesp-monitor-modal-confirm.component");
var justificativa_service_1 = require("./../../service/justificativa.service");
var core_1 = require("@angular/core");
var justificativa_1 = require("../../models/justificativa");
var acao_1 = require("../../models/acao");
var motivo_1 = require("../../models/motivo");
var http_1 = require("@angular/http");
var ProdespItemJustificativaComponent = (function () {
    function ProdespItemJustificativaComponent(justificativaService, dialogService) {
        this.justificativaService = justificativaService;
        this.dialogService = dialogService;
        this.acoes = [];
        this.motivos = [];
    }
    ProdespItemJustificativaComponent.prototype.ngOnInit = function () {
        this.buscarItem();
    };
    ProdespItemJustificativaComponent.prototype.ngOnChanges = function (changes) {
    };
    ProdespItemJustificativaComponent.prototype.buscarItem = function () {
        var _this = this;
        this.isLoading = true;
        this.motivoSelecionado = new motivo_1.Motivo();
        this.acaoSelecionado = new acao_1.Acao();
        this.novaJustificativa = new justificativa_1.Justificativa();
        this.novaJustificativa.IdItemMonitoramento = this.idItem;
        this.justificativaService
            .buscarPorItemMonitoramento(this.idItem, this.codTipoJustificativa)
            .map(function (response) {
            _this.isLoading = false;
            var data = response.json();
            if (data.Id !== 0) {
                _this.novaJustificativa = data;
                _this.motivoSelecionado = new motivo_1.Motivo(data.Motivo.Id, data.Motivo.Nome, data.Motivo.PodeEditarJustificativa, data.Motivo.JustificativaObrigatoria, data.Motivo.justificativa);
                _this.acaoSelecionado = new acao_1.Acao(data.Acao.Id, data.Acao.Nome, data.Acao.PodeEditarJustificativa, data.Acao.JustificativaObrigatoria, data.Acao.justificativa);
            }
            else {
                _this.novaJustificativa.IdJustificador = _this.codTipoJustificativa;
            }
            _this.novaJustificativa.IdItemGsnet = _this.idItemGsnet;
            _this.novaJustificativa.IdGestorMonitor = _this.idGestor;
            _this.podeJustificar = _this.verificarPermissaoPublicacao();
        }).catch(function (error) {
            _this.isLoading = false;
            return Observable_1.Observable.throw(error);
        }).subscribe();
    };
    ProdespItemJustificativaComponent.prototype.onMotivoChange = function (item) {
        var id = parseInt(item.split(':')[1].trim());
        this.motivoSelecionado = this.motivos.find(function (x) { return x.Id === id; });
    };
    ProdespItemJustificativaComponent.prototype.onAcaoChange = function (item) {
        var id = parseInt(item.split(':')[1].trim());
        this.acaoSelecionado = this.acoes.find(function (x) { return x.Id === id; });
    };
    ProdespItemJustificativaComponent.prototype.verificarPermissaoPublicacao = function () {
        var naoPossuiJustificativa = (this.novaJustificativa.Id === 0 || !this.novaJustificativa.Id);
        if (!naoPossuiJustificativa) {
            return false;
        }
        var justificadorComPermissao = (parseInt(this.codTipoJustificativa.toString()) === parseInt(this.idJustificador.toString()));
        var podeJustificarConsultaPublica = (parseInt(this.codTipoJustificativa.toString()) === 4 && parseInt(this.idJustificador.toString()) === 2);
        var possuiPermissao = (naoPossuiJustificativa && justificadorComPermissao) || (naoPossuiJustificativa && podeJustificarConsultaPublica);
        return possuiPermissao;
    };
    ProdespItemJustificativaComponent.prototype.justificar = function () {
        var _this = this;
        this.isLoading = true;
        this.justificativaService.justificar(this.novaJustificativa).map(function (response) {
            _this.isLoading = false;
            if (response.ok) {
                _this.abrirMensagemSucesso('Item Justificado com sucesso');
                _this.buscarItem();
            }
        }).catch(function (error) { return _this.tratarErro(error); }).subscribe();
    };
    ProdespItemJustificativaComponent.prototype.usarAnterior = function () {
        var _this = this;
        this.justificativaService.usarAnterior(this.novaJustificativa).map(function (response) {
            if (response.ok) {
                _this.abrirMensagemSucesso('Item Justificado com sucesso');
                _this.buscarItem();
            }
        }).catch(function (error) { return _this.tratarErro(error); }).subscribe();
    };
    ProdespItemJustificativaComponent.prototype.abrirMensagemSucesso = function (msg) {
        this.dialogService.addDialog(prodesp_monitor_modal_confirm_component_1.ProdespMonitorModalConfirmComponent, {
            title: 'Solicitação efetivada com sucesso',
            text: msg,
            closeButtonText: 'Fechar',
            confirmButtonText: 'Utilizar',
            showConfirmButton: false
        }).subscribe(function (result) {
        });
    };
    ProdespItemJustificativaComponent.prototype.tratarErro = function (error) {
        this.isLoading = false;
        debugger;
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
        return Observable_1.Observable.throw(error);
    };
    return ProdespItemJustificativaComponent;
}());
__decorate([
    core_1.Input(),
    __metadata("design:type", Number)
], ProdespItemJustificativaComponent.prototype, "idItem", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", Number)
], ProdespItemJustificativaComponent.prototype, "idItemGsnet", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", Number)
], ProdespItemJustificativaComponent.prototype, "idGestor", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", Number)
], ProdespItemJustificativaComponent.prototype, "idJustificador", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", String)
], ProdespItemJustificativaComponent.prototype, "codSetor", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", Number)
], ProdespItemJustificativaComponent.prototype, "codTipoJustificativa", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", Array)
], ProdespItemJustificativaComponent.prototype, "acoes", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", Array)
], ProdespItemJustificativaComponent.prototype, "motivos", void 0);
ProdespItemJustificativaComponent = __decorate([
    core_1.Component({
        selector: 'prodesp-item-justificativa',
        templateUrl: './prodesp-item-justificativa.component.html',
        styleUrls: ['./prodesp-item-justificativa.component.css']
    }),
    __metadata("design:paramtypes", [justificativa_service_1.JustificativaService, ng2_bootstrap_modal_1.DialogService])
], ProdespItemJustificativaComponent);
exports.ProdespItemJustificativaComponent = ProdespItemJustificativaComponent;
//# sourceMappingURL=prodesp-item-justificativa.component.js.map