using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Keys;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prodesp.Gsnet.Monitor.Domain.Validacoes;

namespace Prodesp.Gsnet.Monitor.Domain.Entidades
{
    public class Monitoramento : IVigencia, ILongEntityKey, ISelfValidation
    {
        public long Id { get; set; }
        public int? IdPrograma { get; set; }
        public int TipoRegra { get; set; }
        public int? QuantidadeAlertas { get; set; }
        public ICollection<ItemMonitoramento> Itens { get; set; }
        public DateTime DataMonitoramento { get; set; }
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
