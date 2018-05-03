export class RegraMotor {
    constructor(public IdRegraMotor?: number,
        public NomePrograma?: string ,
         public Tipo?: number ,
         public NomeTipoParametro?: string,
          public Vigencia?: string,
           public FlagAtivo?: boolean,
           public QtdeMeses?: number,
           public Autonomia: string = '',
           public Apresentacao: string = '',
           public ConsumoMensal: string = '',
           public DtInicial: string = '',
           public DtFinal: string = '',
           public NomeParametro: string = '',
           public FormulaCalculo: string = '',
           public ValorParametro: string = ''
                ) { }
            decodeSituacao(): string {
                return this.FlagAtivo ? 'Ativo' : 'Inativo';

    }

}
