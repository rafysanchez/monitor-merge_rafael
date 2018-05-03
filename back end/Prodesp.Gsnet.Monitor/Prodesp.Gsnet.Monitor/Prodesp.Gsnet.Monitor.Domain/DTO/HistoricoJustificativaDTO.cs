using Prodesp.Gsnet.Monitor.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Domain.DTO
{
    public class HistoricoJustificativaDTO
    {
        public long IdItemMonitoramento { get; set; }

        public DateTime? DataUltimaFatura { get; set; }
        public DateTime? DataUltimoEmpenho { get; set; }
        public DateTime? DataMonitoramento { get; set; }
        public short? TipoConsumo { get; set; }
        public long? ConsumoMedex { get; set; }
        public long? SaldoDisponivel { get; set; }
        public Justificativa JustificativaCAF { get; set; }
        public Justificativa JustificativaCAFPublica { get; set; }
        public Justificativa JustificativaFME { get; set; }
        public Justificativa JustificativaCompras { get; set; }
        public string NomeFarmacia { get; set; }
        public string NomeMedicamento { get; set; }
        public DateTime DataInicioVigencia { get; set; }
    }
}
