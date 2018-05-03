using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prodesp.Gsnet.Monitor.Domain.Validacoes;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Keys;

namespace Prodesp.Gsnet.Monitor.Domain.Entidades
{
    public class ItemProgramaSaude : IVigencia, IIntEntityKey, ISelfValidation
    {
        public int Id { get; set; }
        public int IdProgramaSaude { get; set; }
        public int IdItem { get; set; }
        public string CodigoGrupoRecurso { get; set; }
        public DateTime DataInicioVigencia { get; set; }
        public DateTime? DataFimVigencia { get; set; }
        public string FlagAtivo { get; set; }

        public ValidationResult ValidationResult
        {
            get;
        }

        public bool IsValid
        {
            get;
        }
    }
}
