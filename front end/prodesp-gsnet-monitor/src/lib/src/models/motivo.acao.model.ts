export class MotivoAcao {
    constructor(public Id?: number, public Nome?: string, public Descricao?: string,
                public DataInclusao?: string, public PodeEditarJustificativa?: boolean,
                public Situacao?: boolean,
                public JustificativaObrigatoria?: boolean,
                public Tipo?: string
            ) {

    }
    decodeSituacao(): string{
        return this.Situacao ? 'Ativo' : 'Inativo';
    }
}
