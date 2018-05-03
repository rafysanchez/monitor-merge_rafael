import { FluxoJustificacao } from './fluxo.justicacao';

export class Medicamento {
    constructor( public Grupo: string, public Codigo: number, public Nome: string, public UnidadeDistribuicao: string,
    public SaldoDisponivel: number, public DiasAutonomia: number, public DataUltimaFatura: string, public QuantidadeUltimaFatura: number,
    public DataUltimoConsumo: string, public Local: string, public FluxoJustificacao: FluxoJustificacao, public Justificado: boolean) {
        // constructor logic here
    }
}
