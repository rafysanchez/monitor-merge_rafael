using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prodesp.Gsnet.Monitor.Domain.Validacoes;
using Prodesp.Gsnet.Monitor.Domain.Entidades.Validations;
namespace Prodesp.Gsnet.Monitor.Domain.Entidades

{
    public class ProgramaSaude :  ISelfValidation
    {
        public int IdProgramaSaude { get; set; }
        public int IdGsnet { get; set; }
        public string NomePrograma { get; set; }
        public string CodigoProgramaSaude { get; set; }
        public DateTime DataInicioVigencia { get; set; }
        public DateTime? DataFimVigencia { get; set; }
        public string FlagAtivo { get; set; }
        public int? IdUsuario { get; set; }

        public ValidationResult ValidationResult
        {
            get;
            set;
        }

        public bool IsValid
        {
            get;
            set;
        }

    }
}
