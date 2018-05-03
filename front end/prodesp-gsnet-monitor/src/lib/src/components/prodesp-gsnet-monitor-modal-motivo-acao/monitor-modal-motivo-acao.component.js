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
var tipoacaomotivo_1 = require("./../../models/tipoacaomotivo");
var dialog_service_1 = require("ng2-bootstrap-modal/dist/dialog.service");
var core_1 = require("@angular/core");
var modal_component_model_1 = require("../../models/modal.component.model");
var motivoacao_service_1 = require("../../service/motivoacao.service");
var ProdespGsnetMonitorModalMotivoAcaoComponent = (function (_super) {
    __extends(ProdespGsnetMonitorModalMotivoAcaoComponent, _super);
    function ProdespGsnetMonitorModalMotivoAcaoComponent(dialogService, service) {
        var _this = _super.call(this, dialogService) || this;
        _this.service = service;
        _this.mensagem = null;
        _this.Tipos = [];
        return _this;
    }
    ProdespGsnetMonitorModalMotivoAcaoComponent.prototype.ngOnInit = function () {
        this.Tipos = [
            new tipoacaomotivo_1.TipoAcaoMotivo(0, 'Ação'),
            new tipoacaomotivo_1.TipoAcaoMotivo(1, 'Motivo'),
        ];
    };
    ProdespGsnetMonitorModalMotivoAcaoComponent.prototype.confirm = function (data) {
        this.result = this.novoMotivoAcao;
        this.close();
    };
    ProdespGsnetMonitorModalMotivoAcaoComponent.prototype.limparMotivoAcao = function () {
        this.novoMotivoAcao.Nome = '';
        this.novoMotivoAcao.Descricao = '';
        this.novoMotivoAcao.Tipo = '';
        this.novoMotivoAcao.PodeEditarJustificativa = false;
        this.novoMotivoAcao.JustificativaObrigatoria = false;
        this.novoMotivoAcao.Situacao = false;
    };
    return ProdespGsnetMonitorModalMotivoAcaoComponent;
}(modal_component_model_1.ModalComponent));
ProdespGsnetMonitorModalMotivoAcaoComponent = __decorate([
    core_1.Component({
        selector: 'prodesp-gsnet-monitor-modal-motivo-acao',
        templateUrl: './monitor-modal-motivo-acao.component.html',
        styleUrls: ['./monitor-modal-motivo-acao.component.css']
    }),
    __metadata("design:paramtypes", [dialog_service_1.DialogService, motivoacao_service_1.MotivoAcaoService])
], ProdespGsnetMonitorModalMotivoAcaoComponent);
exports.ProdespGsnetMonitorModalMotivoAcaoComponent = ProdespGsnetMonitorModalMotivoAcaoComponent;
//# sourceMappingURL=monitor-modal-motivo-acao.component.js.map