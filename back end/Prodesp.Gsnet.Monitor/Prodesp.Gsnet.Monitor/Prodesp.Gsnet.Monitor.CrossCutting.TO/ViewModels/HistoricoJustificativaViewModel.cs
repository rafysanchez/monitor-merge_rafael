using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.CrossCutting.TO.ViewModels
{
    public class HistoricoJustificativaViewModel
    {
        public string NomeMedicamento { get; set; }
        public string NomeFarmacia { get; set; }
    }
    public class ListHistoricoJustificativaViewModel
    {
        public string JustificativaFME { get; set; }
        public string JustificativaCompras { get; set; }
        public string JustificativaCAF { get; set; }
        public string JustificativaCAFPublica { get; set; }
        public string SaldoDisponivel { get; set; }
        public string DataUltimaFatura { get; set; }
        public string DataUltimoEmpenho { get; set; }
        public string DataMonitoramento { get; set; }
        public string DataMonitoramentoExtenso { get; set; }
        public string DataInicioVigencia { get; set; }
        public string ConsumoMedex { get; set; }
    }
}
