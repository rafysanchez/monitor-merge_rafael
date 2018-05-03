using Prodesp.Gsnet.Monitor.Domain.Entidades.Specifications;
using Prodesp.Gsnet.Monitor.Domain.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Domain.Entidades.Validations
{
    public class JustificativaValidation : Validation<Justificativa>
    {
        public JustificativaValidation()
        {
            base.AddRule(new ValidationRule<Justificativa>(new JustificativaMotivoRequired(), "O campo Motivo é Obrigatório"));
            base.AddRule(new ValidationRule<Justificativa>(new JustificativaAcaoRequired(), "O campo Acao é obrigatório"));
        }
    }
}
