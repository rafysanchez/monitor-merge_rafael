using Prodesp.Gsnet.Monitor.Domain.Entidades.Specifications;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Validacoes;
using Prodesp.Gsnet.Monitor.Domain.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Domain.Entidades.Validations
{
    public class MotivoAcaoValidation : Validation<MotivoAcao>
    {
        public MotivoAcaoValidation()
        {
            base.AddRule(new ValidationRule<MotivoAcao>(new MotivoAcaoNomeIsRequired(), "O campo nome é Obrigatório"));
            base.AddRule(new ValidationRule<MotivoAcao>(new MotivoAcaoMaxLengthDescricao(), "O campo Descrição é maior que o permitido"));
        }
    }
}
