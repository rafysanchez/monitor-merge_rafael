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
var config_service_1 = require("./config.service");
var core_1 = require("@angular/core");
var http_1 = require("@angular/http");
var prodesp_core_1 = require("prodesp-core");
var JustificativaService = (function (_super) {
    __extends(JustificativaService, _super);
    function JustificativaService(http, appConfig) {
        var _this = this;
        var _host = appConfig.getConfig('host');
        _this = _super.call(this, _host + '/api/justificativa', http) || this;
        _this.host = _host;
        return _this;
    }
    JustificativaService.prototype.justificar = function (request) {
        return this.getHttpContext().post(this.host + "api/justificativa/justificar", request);
    };
    JustificativaService.prototype.usarAnterior = function (request) {
        return this.getHttpContext().post(this.host + "api/justificativa/usarAnterior", request);
    };
    JustificativaService.prototype.buscarHistorico = function (idItemGsnet, idPrograma, idGestor) {
        return this.getHttpContext().get(this.host + "api/justificativa/historico/" + idPrograma + "/" + idItemGsnet + "/" + idGestor + "?TYPE=json");
    };
    JustificativaService.prototype.buscarItemsMonitorados = function (request) {
        return this.getHttpContext().post(this.host + "api/itemmonitor/queryitens?TYPE=json", request);
    };
    JustificativaService.prototype.buscarPorItemMonitoramento = function (iditem, idJustificador) {
        return this.getHttpContext().get(this.host + "api/justificativa/BuscarPorItem/" + iditem + "/" + idJustificador + "?TYPE=json");
    };
    JustificativaService.prototype.buscarUltimasJustificativas = function (idItem, idJustificador, idGestor) {
        return this.getHttpContext().get(this.host + "api/justificativa/BuscarUltimasJustificativas/" + idItem + "/" + idJustificador + "/" + idGestor + "?TYPE=json");
    };
    JustificativaService.prototype.usarJustificativaAnterior = function (data) {
        return this.getHttpContext().post(this.host + "api/justificativa/UsarJustificativaAnterior", data);
    };
    JustificativaService.prototype.justificarVarios = function (data) {
        return this.getHttpContext().post(this.host + "api/justificativa/JustificarVarios", data);
    };
    JustificativaService.prototype.deletarVarios = function (data) {
        return this.getHttpContext().post(this.host + "api/justificativa/DeletarVarios", data);
    };
    JustificativaService.prototype.justificarPorPrograma = function (data) {
        return this.getHttpContext().post(this.host + "api/justificativa/justificarPorPrograma", data);
    };
    return JustificativaService;
}(prodesp_core_1.BaseService));
JustificativaService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http, config_service_1.AppConfig])
], JustificativaService);
exports.JustificativaService = JustificativaService;
//# sourceMappingURL=justificativa.service.js.map