using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.CrossCutting.TO.ViewModels
{
    public class JustificativaViewModel
    {
        public int Id { get; set; }
        public int IdItemGsnet { get; set; }
        public int IdItemMonitoramento { get; set; }
        public int IdGestorMonitor { get; set; }
        public int IdMotivo { get; set; }
        public MotivoAcaoViewModel Motivo { get; set; }
        public int IdAcao { get; set; }
        public MotivoAcaoViewModel Acao { get; set; }
        public int IdUsuario { get; set; }
        public int IdJustificador { get; set; }
        public string DataJustificativa { get; set; }
        public string MotivoJustificativa { get; set; }
        public string AcaoJustificativa { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
