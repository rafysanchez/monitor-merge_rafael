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
var http_1 = require("@angular/http");
var core_1 = require("@angular/core");
var prodesp_core_1 = require("prodesp-core");
require("rxjs/add/operator/map");
require("rxjs/add/operator/catch");
require("rxjs/add/observable/throw");
var RegraMotorService = (function (_super) {
    __extends(RegraMotorService, _super);
    function RegraMotorService(http, appConfig) {
        var _this = this;
        var host = appConfig.getConfig('host');
        _this = _super.call(this, host + 'api/regrammotor', http) || this;
        return _this;
    }
    RegraMotorService.prototype.Cadastrar = function (parametro) {
        var httpContext = this.getHttpContext();
        return httpContext.post(this.url + "/InserirDadosRegraParametroValor", parametro);
    };
    RegraMotorService.prototype.Editar = function (parametro) {
        var httpContext = this.getHttpContext();
        return httpContext.post(this.url + "/EditarDadosRegraParametroValor", parametro);
    };
    return RegraMotorService;
}(prodesp_core_1.BaseService));
RegraMotorService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http, config_service_1.AppConfig])
], RegraMotorService);
exports.RegraMotorService = RegraMotorService;
//# sourceMappingURL=regramotor.service.js.map