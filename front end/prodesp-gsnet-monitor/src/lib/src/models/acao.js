"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Acao = (function () {
    function Acao(Id, Nome, PodeEditarJustificativa, JustificativaObrigatoria, justificativa) {
        if (Id === void 0) { Id = 0; }
        if (Nome === void 0) { Nome = ''; }
        this.Id = Id;
        this.Nome = Nome;
        this.PodeEditarJustificativa = PodeEditarJustificativa;
        this.JustificativaObrigatoria = JustificativaObrigatoria;
        this.justificativa = justificativa;
    }
    return Acao;
}());
exports.Acao = Acao;
//# sourceMappingURL=acao.js.map