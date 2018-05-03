using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.CrossCutting.TO.ViewModels
{
    public class TipoMotivoViewModel
    {
        public int Id { get; set; }
        //public int UserId { get; set; }
        public string Descricao { get; set; }
        public string Situacao { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
