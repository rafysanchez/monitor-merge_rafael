export class ParametroLista {
    constructor(public IdRegraMotor?: number,
        public NomePrograma?: string ,
         public Tipo?: string ,
         public NomeTipoParametro?: string,
          public Vigencia?: string,
           public FlagAtivo?: boolean,
           public TpParametro: string = ''
        ) { }
            decodeSituacao(): string {
                return this.FlagAtivo ? 'Ativo' : 'Inativo';

    }

}
