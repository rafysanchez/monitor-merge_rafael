"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Indicadores = (function () {
    function Indicadores(percentualCriticidade, quantidadeCriticidade, quantidadeJustificativas, dataReferencia) {
        if (percentualCriticidade === void 0) { percentualCriticidade = ''; }
        if (quantidadeCriticidade === void 0) { quantidadeCriticidade = 0; }
        if (quantidadeJustificativas === void 0) { quantidadeJustificativas = 0; }
        if (dataReferencia === void 0) { dataReferencia = ''; }
        this.percentualCriticidade = percentualCriticidade;
        this.quantidadeCriticidade = quantidadeCriticidade;
        this.quantidadeJustificativas = quantidadeJustificativas;
        this.dataReferencia = dataReferencia;
    }
    return Indicadores;
}());
exports.Indicadores = Indicadores;
//# sourceMappingURL=indicadores.model.js.map