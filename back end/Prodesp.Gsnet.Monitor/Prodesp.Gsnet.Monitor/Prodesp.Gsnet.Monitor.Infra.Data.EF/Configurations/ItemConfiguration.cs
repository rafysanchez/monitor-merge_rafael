using Prodesp.Gsnet.Monitor.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Infra.Data.EF.Configurations
{
    public class ItemConfiguration : BaseVigenciaTypeConfiguration<Item,int>
    {
        public ItemConfiguration() : base("MON_ITENS", "ID_ITEM_MONITOR")
        {
            Property(x => x.IdGsnet).HasColumnName("ID_ITEM_GSNET").IsRequired();
            Property(x => x.IdUnidadeMedida).HasColumnName("ID_UNIDADE_MEDIDA").IsRequired();
            Property(x => x.Nome).HasColumnName("NM_ITEM").IsRequired();
            Property(x => x.CodigoSIAFISICO).HasColumnName("CD_SIAFISICO").IsRequired();
            Property(x => x.CodigoMedicamento).HasColumnName("CD_MEDICAMENTO");
        }
    }
}
