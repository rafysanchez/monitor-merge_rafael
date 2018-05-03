import { Acao } from './acao';
import { Motivo } from './motivo';
export class Justificativa {
    public Id: number;
    public IdItemMonitoramento: number;
    public IdGestorMonitor: number;
    public IdMotivo: number;
    public IdAcao: number;
    public IdUsuario: number;
    public IdJustificador: number;
    public DataJustificativa: string;
    public MotivoJustificativa: null;
    public AcaoJustificativa: null;
    public DataInclusao: string;
    public DataAlteracao: null;
    public Motivo: Motivo;
    public Acao: Acao;
    public IdItemGsnet: number;
    constructor() {
        this.Acao = new Acao();
        this.Motivo = new Motivo();
    }
    toString(): string {
        return `Motivo: ${this.Motivo.Nome} Ação : ${this.Acao.Nome}`;
    }
}
