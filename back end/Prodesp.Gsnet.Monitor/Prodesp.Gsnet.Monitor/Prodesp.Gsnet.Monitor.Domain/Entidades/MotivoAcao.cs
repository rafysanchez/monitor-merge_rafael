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
    public class MotivoAcao : ISelfValidation
    {
        public int Id { get; set; }
        public int IdUsuarioInclusao { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public short Tipo { get; set; }
        public short PodeEditarJustificativa { get; set; }
        public short JustificativaObrigatoria { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public string FlagAtivo { get; set; }

        public bool ValidarObrigatoriedadeComplementoDescricao()
        {
            return this.PodeEditarJustificativa == 1 && this.JustificativaObrigatoria == 1;
        }
        public ValidationResult ValidationResult
        {
            get
            {
                var validacao = new MotivoAcaoValidation();
                return validacao.Validate(this);
            }
        }

        public bool IsValid
        {
            get
            {                
                return this.ValidationResult.IsValid;
            }
        }

    }
}
