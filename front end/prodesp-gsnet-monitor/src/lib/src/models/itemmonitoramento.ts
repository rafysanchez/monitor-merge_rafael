export interface ItemMonitoramento {
    Id:                        number;
    IdMonitoramento:           number;
    Nome:                      string;
    Local:                     null;
    GrupoRecursos:             null;
    UnidadeDistribuicao:       string;
    Justificado:               boolean;
    QuantidadeSaldoDisponivel: number;
    QuantidadeDiasAutonomia:   number;
    QuantidadeUltimaFatura:    null;
    DataUltimaFatura:          null;
    QuantidadeUltimoEmpenho:   null;
    DataUltimoEmpenho:         null;
    QuantidadeUltimoConsumo:   null;
    DataUltimoConsumo:         null;
    TipoConsumo?:              number;
    QuantidadeConsumo?:        number;
    TipoRegra:                 number;
    CodigoSIAFISICO:           string;
    CodigoMedicamento:         string;
}
