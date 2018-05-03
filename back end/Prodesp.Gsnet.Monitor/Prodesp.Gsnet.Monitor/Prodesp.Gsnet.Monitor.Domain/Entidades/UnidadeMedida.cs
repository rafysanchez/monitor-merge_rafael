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
    public class UnidadeMedida : IVigencia, IIntEntityKey, ISelfValidation
    {
        public int Id { get; set; }
        public int IdGsnet { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }

        #region IVigencia members
        public DateTime DataInicioVigencia { get; set; }
        public DateTime? DataFimVigencia { get; set; }
        public string FlagAtivo { get; set; }
        #endregion
        #region ISelfValidation Members
        public ValidationResult ValidationResult
        {
            get;
        }

        public bool IsValid
        {
            get;
        }
        #endregion

    }
}
