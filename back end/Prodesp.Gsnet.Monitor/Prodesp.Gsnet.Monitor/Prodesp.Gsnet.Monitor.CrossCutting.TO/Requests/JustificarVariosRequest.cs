using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.CrossCutting.TO.Requests
{
    public class JustificarVariosRequest
    {
        public int IdAcao { get; set; }
        public int IdMotivo { get; set; }
        public string MotivoJustificativa { get; set; }
        public string AcaoJustificativa { get; set; }
        public int IdJustificador { get; set; }
        public ItemRequest[] Itens { get; set; }
    }
    public class ItemRequest
    {
        public int IdItemMonitoramento { get; set; }
        public int IdItemGsnet { get; set; }
        public int IdGestorMonitor { get; set; }
    }
}
