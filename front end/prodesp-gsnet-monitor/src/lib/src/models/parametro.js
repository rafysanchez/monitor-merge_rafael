"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Parametro = (function () {
    function Parametro(IdRegraMotor, NomePrograma, Tipo, NomeTipoParametro, Vigencia, FlagAtivo, QtdeMeses, Apresentacao, ConsumoMensal, DtInicial, DtFinal, NomeParametro, FormulaCalculo, ValorParametro, Autonomia, IdProgramaMonitor, DtFinal_) {
        if (Apresentacao === void 0) { Apresentacao = ''; }
        if (ConsumoMensal === void 0) { ConsumoMensal = ''; }
        if (DtInicial === void 0) { DtInicial = ''; }
        if (DtFinal === void 0) { DtFinal = ''; }
        if (NomeParametro === void 0) { NomeParametro = ''; }
        if (FormulaCalculo === void 0) { FormulaCalculo = ''; }
        if (ValorParametro === void 0) { ValorParametro = ''; }
        if (Autonomia === void 0) { Autonomia = ''; }
        if (DtFinal_ === void 0) { DtFinal_ = ''; }
        this.IdRegraMotor = IdRegraMotor;
        this.NomePrograma = NomePrograma;
        this.Tipo = Tipo;
        this.NomeTipoParametro = NomeTipoParametro;
        this.Vigencia = Vigencia;
        this.FlagAtivo = FlagAtivo;
        this.QtdeMeses = QtdeMeses;
        this.Apresentacao = Apresentacao;
        this.ConsumoMensal = ConsumoMensal;
        this.DtInicial = DtInicial;
        this.DtFinal = DtFinal;
        this.NomeParametro = NomeParametro;
        this.FormulaCalculo = FormulaCalculo;
        this.ValorParametro = ValorParametro;
        this.Autonomia = Autonomia;
        this.IdProgramaMonitor = IdProgramaMonitor;
        this.DtFinal_ = DtFinal_;
    }
    Parametro.prototype.decodeSituacao = function () {
        return this.FlagAtivo ? 'Ativo' : 'Inativo';
    };
    Parametro.prototype.ajustataFinal = function () {
        return null;
    };
    return Parametro;
}());
exports.Parametro = Parametro;
//# sourceMappingURL=parametro.js.map