export class Acao {
    constructor(public Id: number = 0, public Nome: string = '',
                public PodeEditarJustificativa?: boolean,
                public JustificativaObrigatoria?: boolean,
                public justificativa?: string) {
        // constructor logic here
    }
}
