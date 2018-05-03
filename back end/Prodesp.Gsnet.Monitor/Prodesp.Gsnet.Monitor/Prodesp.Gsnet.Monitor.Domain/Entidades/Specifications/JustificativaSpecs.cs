using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Domain.Entidades.Specifications
{
    public class JustificativaAcaoRequired : ISpecification<Justificativa>
    {
        public bool IsSatisfiedBy(Justificativa entity)
        {
            return entity.IdAcao != 0;
        }
    }
    public class JustificativaMotivoRequired : ISpecification<Justificativa>
    {
        public bool IsSatisfiedBy(Justificativa entity)
        {
            return entity.IdMotivo != 0;
        }
    }
}
