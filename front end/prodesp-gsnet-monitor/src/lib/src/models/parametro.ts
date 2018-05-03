export class Parametro {
    constructor(
                public IdRegraMotor?: number,
                public NomePrograma?: string ,
                public Tipo?: number ,
                public NomeTipoParametro?: string,
                public Vigencia?: string,
                public FlagAtivo?: boolean,
                public QtdeMeses?: number,
                public Apresentacao: string = '',
                public ConsumoMensal: string = '',
                public DtInicial: string = '',
                public DtFinal: string = '',
                public NomeParametro: string = '',
                public FormulaCalculo: string = '',
                public ValorParametro: string = '',
                public Autonomia: string = '',
                public IdProgramaMonitor?: number,
                public DtFinal_: string = ''
                ) { }
            decodeSituacao(): string {
                return this.FlagAtivo ? 'Ativo' : 'Inativo';

    }
    ajustataFinal(): string {

        return null;
    }
}
