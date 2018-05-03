using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Validacoes;
using System;
using Prodesp.Gsnet.Monitor.Domain.Validacoes;
using System.Collections.Generic;

namespace Prodesp.Gsnet.Monitor.Domain.Entidades
{
    public class RegraMotor : ISelfValidation
    {
        
        public int IdRegraMotor { get; set; }
        public int IdProgramaMotor { get; set; }
        public int TpParametro { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataInicioVigencia { get; set; }
        public DateTime? DataFimVigencia { get; set; }
        public string FlagAtivo { get; set; }
        public string FlStatus { get; set; }
        //public int IdProgramaSaude { get; set; }
        public virtual ProgramaSaude PogramaSaude { get; set; }


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
