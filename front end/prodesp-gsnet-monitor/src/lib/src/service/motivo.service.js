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
var motivo_1 = require("./../models/motivo");
var core_1 = require("@angular/core");
var MotivoService = (function () {
    function MotivoService() {
    }
    MotivoService.prototype.get = function () {
        return [
            new motivo_1.Motivo(1, 'Falha na Programação'),
            new motivo_1.Motivo(2, 'Paciente Novo'),
            new motivo_1.Motivo(3, 'Aguardando Emissão de Fatura'),
            new motivo_1.Motivo(4, 'Aguardando entrega da Furp'),
            new motivo_1.Motivo(0, 'Outros'),
        ];
    };
    return MotivoService;
}());
MotivoService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [])
], MotivoService);
exports.MotivoService = MotivoService;
//# sourceMappingURL=motivo.service.js.map