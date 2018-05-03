using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prodesp.Gsnet.Monitor.Domain.Validacoes;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Keys;
using Prodesp.Gsnet.Monitor.Domain.Entidades.Validations;

namespace Prodesp.Gsnet.Monitor.Domain.Entidades
{
    public class Justificativa : ISelfValidation, IIntEntityKey
    {
        public int Id { get; set; }
        public int IdItemGsnet { get; set; }
        public int IdGestorMonitor { get; set; }
        public long IdItemMonitoramento { get; set; }
        public int IdMotivo { get; set; }
        public int IdAcao { get; set; }
        public int IdUsuario { get; set; }
        public int IdJustificador { get; set; }

        public DateTime DataJustificativa { get; set; }

        public virtual MotivoAcao Motivo { get; set; }
        public string MotivoJustificativa { get; set; }
        public virtual MotivoAcao Acao { get; set; }
        public string AcaoJustificativa { get; set; }

        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public ValidationResult ValidationResult
        {
            get
            {
                JustificativaValidation validation = new JustificativaValidation();
                return validation.Validate(this);
            }
        }

        public bool IsValid
        {
            get
            {
                return true;
            }
        }
        public override string ToString()
        {
            return $"Motivo: {this.Motivo?.Descricao } | Ação : {this.Acao?.Descricao }";
        }
    }
}
