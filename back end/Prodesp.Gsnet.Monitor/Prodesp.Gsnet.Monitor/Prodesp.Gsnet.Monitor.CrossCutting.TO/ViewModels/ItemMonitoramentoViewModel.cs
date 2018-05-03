using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.CrossCutting.TO.ViewModels
{
    public class ItemMonitoramentoViewModel
    {
        public int Id { get; set; }
        public int IdItemProgramaGestor { get; set; }
        public int IdMonitoramento { get; set; }
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
        public string DataUltimoConsumo { get; set; }
        public short TipoConsumo { get; set; }
        public long? QuantidadeConsumo { get; set; }
        public short? TipoRegra { get; set; }
    }
}
