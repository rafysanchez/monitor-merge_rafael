using System;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Validacoes;
using Prodesp.Gsnet.Monitor.Domain.Validacoes;

namespace Prodesp.Gsnet.Monitor.Domain.Entidades
{
    public  class ParametroValor : ISelfValidation
    {
        public int IdParametroValor { get; set; }
        public int IdParametro { get; set; }
        public int IdRegraMotor { get; set; }
        public string VlParametro { get; set; }
        public RegraMotor Regra { get; set; }
        public virtual Parametro Parametro { get; set; }
        public ValidationResult ValidationResult
        {
            get
            {
                return new ValidationResult();
            }
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
