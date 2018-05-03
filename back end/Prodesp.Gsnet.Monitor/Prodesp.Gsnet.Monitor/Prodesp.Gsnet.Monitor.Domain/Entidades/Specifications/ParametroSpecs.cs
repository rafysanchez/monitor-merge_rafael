using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Domain.Entidades.Specifications
{
    public class ParametroSpecs : ISpecification<Parametro>
    {
        // rever ao funcionar
        public bool IsSatisfiedBy(Parametro entity)
        {
            return string.IsNullOrEmpty(entity.CdParametro) && string.IsNullOrEmpty(entity.CdParametro.Trim());
        }
    }
    public class ParametroMaxLengthDescricao : ISpecification<Parametro>
    {
        public bool IsSatisfiedBy(Parametro entity)
        {
            return string.IsNullOrEmpty(entity.DsParametro)
                && string.IsNullOrEmpty(entity.DsParametro.Trim())
                && entity.DsParametro.Length <= 200;
        }
    }
}
