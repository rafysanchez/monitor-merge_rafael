using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.CrossCutting.TO.ViewModels
{
    public class AcaoViewModel
    {
        public int Id { get; set; }
        public int IdMotivo { get; set; }
        public int IdAcao { get; set; }
        public string Nome { get; set; }
        public string DescricaoComplementarAcao { get; set; }
        public string DescricaoComplementarMotivo { get; set; }
        public virtual TipoAcaoViewModel TipoAcao { get; set; }
        public virtual TipoMotivoViewModel TipoMotivo { get; set; }
        public string FlagPublica { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
