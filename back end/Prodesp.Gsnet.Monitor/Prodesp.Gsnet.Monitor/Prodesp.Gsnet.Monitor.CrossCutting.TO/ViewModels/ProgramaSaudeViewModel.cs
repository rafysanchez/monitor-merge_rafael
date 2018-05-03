using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.CrossCutting.TO.ViewModels
{
   public  class ProgramaSaudeViewModel
    {
        public int Id { get; set; }
        public int IdGsnet { get; set; }
        public string NomePrograma { get; set; }
        public string CodigoProgramaSaude { get; set; }
        public DateTime DataInicioVigencia { get; set; }
        public DateTime? DataFimVigencia { get; set; }
        public string FlagAtivo { get; set; }

        public int? IdUsuario { get; set; }

    }
}
