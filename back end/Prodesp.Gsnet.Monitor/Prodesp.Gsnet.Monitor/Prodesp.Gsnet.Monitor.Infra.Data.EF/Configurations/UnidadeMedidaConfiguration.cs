using Prodesp.Gsnet.Monitor.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Infra.Data.EF.Configurations
{
    public class UnidadeMedidaConfiguration : BaseVigenciaTypeConfiguration<UnidadeMedida,int>
    {
        public UnidadeMedidaConfiguration() : base("MON_UNIDADE_MEDIDA", "ID_UNID_MEDIDA_MONITOR")
        {
            Property(x => x.IdGsnet).HasColumnName("ID_UNID_MEDIDA_GSNET").IsRequired();
            Property(x => x.Sigla).HasColumnName("SG_UNIDADE_MEDIDA").IsRequired();
            Property(x => x.Nome).HasColumnName("NM_UNIDADE_MEDIDA").IsRequired();

        }
    }
}
