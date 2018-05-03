"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var ParametroLista = (function () {
    function ParametroLista(IdRegraMotor, NomePrograma, Tipo, NomeTipoParametro, Vigencia, FlagAtivo, TpParametro) {
        if (TpParametro === void 0) { TpParametro = ''; }
        this.IdRegraMotor = IdRegraMotor;
        this.NomePrograma = NomePrograma;
        this.Tipo = Tipo;
        this.NomeTipoParametro = NomeTipoParametro;
        this.Vigencia = Vigencia;
        this.FlagAtivo = FlagAtivo;
        this.TpParametro = TpParametro;
    }
    ParametroLista.prototype.decodeSituacao = function () {
        return this.FlagAtivo ? 'Ativo' : 'Inativo';
    };
    return ParametroLista;
}());
exports.ParametroLista = ParametroLista;
//# sourceMappingURL=parametroLista.js.map