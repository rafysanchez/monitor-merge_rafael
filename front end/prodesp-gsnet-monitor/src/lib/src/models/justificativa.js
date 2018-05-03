"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var acao_1 = require("./acao");
var motivo_1 = require("./motivo");
var Justificativa = (function () {
    function Justificativa() {
        this.Acao = new acao_1.Acao();
        this.Motivo = new motivo_1.Motivo();
    }
    Justificativa.prototype.toString = function () {
        return "Motivo: " + this.Motivo.Nome + " A\u00E7\u00E3o : " + this.Acao.Nome;
    };
    return Justificativa;
}());
exports.Justificativa = Justificativa;
//# sourceMappingURL=justificativa.js.map