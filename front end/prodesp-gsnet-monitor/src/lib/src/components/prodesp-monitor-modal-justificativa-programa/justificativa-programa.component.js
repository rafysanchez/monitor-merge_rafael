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
var ng2_bootstrap_modal_1 = require("ng2-bootstrap-modal");
var core_1 = require("@angular/core");
var modal_component_model_1 = require("./../../models/modal.component.model");
var justificativa_1 = require("../../models/justificativa");
var acao_service_1 = require("../../service/acao.service");
var motivo_service_1 = require("../../service/motivo.service");
var ProdespMonitorModalJustificativaProgramaComponent = (function (_super) {
    __extends(ProdespMonitorModalJustificativaProgramaComponent, _super);
    function ProdespMonitorModalJustificativaProgramaComponent(acaoService, motivoService, dialogService) {
        var _this = _super.call(this, dialogService) || this;
        _this.acaoService = acaoService;
        _this.motivoService = motivoService;
        _this.programasSaude = [];
        _this.motivos = [];
        _this.acoes = [];
        return _this;
    }
    ProdespMonitorModalJustificativaProgramaComponent.prototype.ngOnInit = function () {
        this.programasSaude = [
            new programa_saude_model_1.ProgramaSaude(1, 'DOSE CERTA'),
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
        this.novaJustificativa = new justificativa_1.Justificativa();
        console.log(this.novaJustificativa);
        this.acoes = this.acaoService.get();
        this.motivos = this.motivoService.get();
    };
    return ProdespMonitorModalJustificativaProgramaComponent;
}(modal_component_model_1.ModalComponent));
ProdespMonitorModalJustificativaProgramaComponent = __decorate([
    core_1.Component({
        selector: 'prodesp-monitor-modal-justificativa-programa',
        templateUrl: './monitor-justificativa-programa.component.html',
        styleUrls: ['./monitor-justificativa-programa.component.css']
    }),
    __metadata("design:paramtypes", [acao_service_1.AcaoService, motivo_service_1.MotivoService, ng2_bootstrap_modal_1.DialogService])
], ProdespMonitorModalJustificativaProgramaComponent);
exports.ProdespMonitorModalJustificativaProgramaComponent = ProdespMonitorModalJustificativaProgramaComponent;
//# sourceMappingURL=justificativa-programa.component.js.map