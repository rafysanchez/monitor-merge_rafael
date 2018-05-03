using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.CrossCutting.TO.ViewModels
{
    public class MotivoAcaoViewModel
    {
        public int Id { get; set; }
        public int IdUsuarioInclusao { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public bool Situacao { get; set; }
        public bool PodeEditarJustificativa { get; set; }
        public bool JustificativaObrigatoria { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
