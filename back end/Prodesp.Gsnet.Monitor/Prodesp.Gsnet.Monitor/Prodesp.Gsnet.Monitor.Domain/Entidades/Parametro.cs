using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Validacoes;
using System;
using Prodesp.Gsnet.Monitor.Domain.Validacoes;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Keys;

namespace Prodesp.Gsnet.Monitor.Domain.Entidades
{
    public class Parametro :   ISelfValidation
    {
        public int Id  { get; set; }
        public int IdUsuario { get; set; }
        public string CdParametro { get; set; }
        public string TpDadoParametro { get; set; }
        public string DsParametro { get; set; }

        public DateTime DtInicioVigencia { get; set; }

        public DateTime? DtFimVigencia { get; set; }
        public string FlagAtivo { get; set; }
        public ValidationResult ValidationResult
        {
            get;
            set;
        }

        public bool IsValid
        {
            get;
            
        }
        
    }
}
