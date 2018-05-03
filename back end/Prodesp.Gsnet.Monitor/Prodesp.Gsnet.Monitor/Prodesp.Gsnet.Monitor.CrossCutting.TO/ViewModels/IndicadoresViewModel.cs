using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.CrossCutting.TO.ViewModels
{
    public class IndicadoresViewModel
    {
        public int Id { get; set; }
        public int QuantidadeAlertas { get; set; }
        public int QuantidadeAlertasItens { get; set; }
        public int JustificativasPendentes { get; set; }
        public string DataMonitoramento { get; set; }
        public string NomePrograma { get; set; }
        public int QuantidadeItens { get; set; }
        public string Percentual { get; set; }
    }
}
