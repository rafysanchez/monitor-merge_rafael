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
var config_service_1 = require("./../service/config.service");
var http_1 = require("@angular/http");
var core_1 = require("@angular/core");
var prodesp_core_1 = require("prodesp-core");
require("rxjs/add/operator/map");
require("rxjs/add/operator/catch");
require("rxjs/add/observable/throw");
var ParametroService = (function (_super) {
    __extends(ParametroService, _super);
    function ParametroService(http, appConfig) {
        var _this = this;
        var host = appConfig.getConfig('host');
        _this = _super.call(this, host + 'api/regramotor/', http) || this;
        return _this;
    }
    ParametroService.prototype.CarregarPorID = function (id) {
        var httpContext = this.getHttpContext();
        return httpContext.get(this.url + "GetByIdDadosAEditar/" + id);
    };
    ParametroService.prototype.Cadastrar = function (parametro) {
        var httpContext = this.getHttpContext();
        return httpContext.post(this.url + "InserirDadosRegraParametroValor", parametro);
    };
    ParametroService.prototype.Editar = function (parametro) {
        var httpContext = this.getHttpContext();
        return httpContext.post(this.url + "EditarDadosRegraParametroValor", parametro);
    };
    return ParametroService;
}(prodesp_core_1.BaseService));
ParametroService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http, config_service_1.AppConfig])
], ParametroService);
exports.ParametroService = ParametroService;
//# sourceMappingURL=parametro.service.js.map