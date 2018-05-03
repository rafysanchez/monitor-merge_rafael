using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.CrossCutting.TO.ViewModels
{
    public class MonitoramentoViewModel
    {
        public int Id { get; set; }
        public int IdPrograma { get; set; }
        public int QuantidadeAlertas { get; set; }
        public virtual ICollection<ItemMonitoramentoViewModel> Itens { get; set; }
        public DateTime DataMonitoramento { get; set; }
        public DateTime DataInicioVigencia { get; set; }
        public DateTime? DataFimVigencia { get; set; }
        public string FlagAtivo { get; set; }        
    }
}
