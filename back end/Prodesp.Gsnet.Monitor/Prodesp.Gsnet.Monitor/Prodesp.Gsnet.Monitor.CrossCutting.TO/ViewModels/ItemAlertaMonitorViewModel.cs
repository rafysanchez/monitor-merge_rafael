using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.CrossCutting.TO.ViewModels
{
    public class ItemAlertaMonitorViewModel
    {
        public long Id { get; set; }
        public int? IdPrograma { get; set; }
        public long IdMonitoramento { get; set; }
        public string Nome { get; set; }
        public string Local { get; set; }
        public string GrupoRecursos { get; set; }
        public string UnidadeDistribuicao { get; set; }
        public bool Justificado { get; set; }
        public long? QuantidadeSaldoDisponivel { get; set; }
        public decimal? QuantidadeDiasAutonomia { get; set; }
        public long? QuantidadeUltimaFatura { get; set; }
        public string DataUltimaFatura { get; set; }
        public long? QuantidadeUltimoEmpenho { get; set; }
        public string DataUltimoEmpenho { get; set; }
        public long? QuantidadeUltimoConsumo { get; set; }
        public string DataMonitoramento { get; set; }
        public string DataUltimoConsumo { get; set; }
        public short? TipoConsumo { get; set; }
        public long? QuantidadeConsumo { get; set; }
        public short? TipoRegra { get; set; }
        public int CodigoSIAFISICO { get; set; }
        public string CodigoMedicamento { get; set; }
        public int IdGestorMonitor { get; set; }
        public int IdItemGsnet { get; set; }
        public bool JustificadoCMP { get; set; }
        public bool JustificadoCAF { get; set; }
        public bool JustificadoFME { get; set; }
        public string FlagAtivo { get; set; }
        public bool JustificadoCAFPublica { get; set; }
    }
}
