using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.CrossCutting.TO.ViewModels
{
    public class ParametroViewModel
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string CdParametro { get; set; }
        public string TpDadoParametro { get; set; }
        public string DsParametro { get; set; }
        public string FlagAtivo { get; set; }
        public DateTime DtInicioVigencia { get; set; }

        public DateTime DtFimVigencia { get; set; }
        public string Vigencia
        {
            get
            {
                var retorno = "";
                retorno = this.DtInicioVigencia.ToShortDateString();
                retorno += " até ";
                retorno += DtFimVigencia.ToShortDateString() == null ? "" : this.DtFimVigencia.ToShortDateString();
                return retorno;
            }

        }
    }
}
