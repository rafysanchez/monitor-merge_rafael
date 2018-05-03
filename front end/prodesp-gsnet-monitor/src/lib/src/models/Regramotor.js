"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var RegraMotor = (function () {
    function RegraMotor(IdRegraMotor, NomePrograma, Tipo, NomeTipoParametro, Vigencia, FlagAtivo, QtdeMeses, Autonomia, Apresentacao, ConsumoMensal, DtInicial, DtFinal, NomeParametro, FormulaCalculo, ValorParametro) {
        if (Autonomia === void 0) { Autonomia = ''; }
        if (Apresentacao === void 0) { Apresentacao = ''; }
        if (ConsumoMensal === void 0) { ConsumoMensal = ''; }
        if (DtInicial === void 0) { DtInicial = ''; }
        if (DtFinal === void 0) { DtFinal = ''; }
        if (NomeParametro === void 0) { NomeParametro = ''; }
        if (FormulaCalculo === void 0) { FormulaCalculo = ''; }
        if (ValorParametro === void 0) { ValorParametro = ''; }
        this.IdRegraMotor = IdRegraMotor;
        this.NomePrograma = NomePrograma;
        this.Tipo = Tipo;
        this.NomeTipoParametro = NomeTipoParametro;
        this.Vigencia = Vigencia;
        this.FlagAtivo = FlagAtivo;
        this.QtdeMeses = QtdeMeses;
        this.Autonomia = Autonomia;
        this.Apresentacao = Apresentacao;
        this.ConsumoMensal = ConsumoMensal;
        this.DtInicial = DtInicial;
        this.DtFinal = DtFinal;
        this.NomeParametro = NomeParametro;
        this.FormulaCalculo = FormulaCalculo;
        this.ValorParametro = ValorParametro;
    }
    RegraMotor.prototype.decodeSituacao = function () {
        return this.FlagAtivo ? 'Ativo' : 'Inativo';
    };
    return RegraMotor;
}());
exports.RegraMotor = RegraMotor;
//# sourceMappingURL=Regramotor.js.map