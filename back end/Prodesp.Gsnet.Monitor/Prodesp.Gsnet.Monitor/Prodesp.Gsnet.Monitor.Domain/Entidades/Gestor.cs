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
    public class Gestor : IIntEntityKey, ISelfValidation, IVigencia
    {
        public int Id
        {
            get;

            set;
        }
        public int IdGsnet { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public DateTime? DataFimVigencia
        {
            get;

            set;
        }

        public DateTime DataInicioVigencia
        {
            get;

            set;
        }

        public string FlagAtivo
        {
            get;

            set;
        }

        public bool IsValid
        {
            get;
        }

        public ValidationResult ValidationResult
        {
            get;
        }
    }
}
