using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Domain.Entidades.Specifications
{
    public class MotivoAcaoNomeIsRequired : ISpecification<MotivoAcao>
    {
        public bool IsSatisfiedBy(MotivoAcao entity)
        {
            return !string.IsNullOrEmpty(entity.Nome) && !string.IsNullOrEmpty(entity.Nome.Trim());
        }
    }
    public class MotivoAcaoMaxLengthDescricao : ISpecification<MotivoAcao>
    {
        public bool IsSatisfiedBy(MotivoAcao entity)
        {
            return !string.IsNullOrEmpty(entity.Descricao)
                && !string.IsNullOrEmpty(entity.Descricao.Trim())
                && entity.Descricao.Length <= 300;
        }
    }    
}
