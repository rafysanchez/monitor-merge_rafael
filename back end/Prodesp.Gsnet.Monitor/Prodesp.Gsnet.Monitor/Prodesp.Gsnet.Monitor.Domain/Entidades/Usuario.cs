using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prodesp.Gsnet.Monitor.Domain.Validacoes;

namespace Prodesp.Gsnet.Monitor.Domain.Entidades
{
    public class Usuario : ISelfValidation
    {
        public int Id { get; set; }
        public int IdGestor { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Codigo { get; set; }
        public string Situacao { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public string FlagUsuarioSistema { get; set; }
        public string FlagAcessoBloqueio { get; set; }
        public Gestor Gestor { get; set; }

        public ValidationResult ValidationResult
        {
            get; private set;
        }

        public bool IsValid
        {
            get
            {
                return true;
            }
        }
    }
}
