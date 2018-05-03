"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var MotivoAcao = (function () {
    function MotivoAcao(Id, Nome, Descricao, DataInclusao, PodeEditarJustificativa, Situacao, JustificativaObrigatoria, Tipo) {
        this.Id = Id;
        this.Nome = Nome;
        this.Descricao = Descricao;
        this.DataInclusao = DataInclusao;
        this.PodeEditarJustificativa = PodeEditarJustificativa;
        this.Situacao = Situacao;
        this.JustificativaObrigatoria = JustificativaObrigatoria;
        this.Tipo = Tipo;
    }
    MotivoAcao.prototype.decodeSituacao = function () {
        return this.Situacao ? 'Ativo' : 'Inativo';
    };
    return MotivoAcao;
}());
exports.MotivoAcao = MotivoAcao;
//# sourceMappingURL=motivo.acao.model.js.map