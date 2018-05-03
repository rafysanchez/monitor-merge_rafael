using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.CrossCutting.TO.ViewModels
{
    public class JustificarPorProgramaViewModel
    {
        public int IdJustificador { get; set; }
        public int IdPrograma { get; set; }
        public MotivoAcaoViewModel Motivo { get; set; }
        public MotivoAcaoViewModel Acao { get; set; }
    }
}
