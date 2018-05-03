using Prodesp.Gsnet.Monitor.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Infra.Data.EF.Configurations
{
    public class ItemProgramaGestorConfiguration : BaseVigenciaTypeConfiguration<ItemProgramaGestor,int>
    {
        public ItemProgramaGestorConfiguration() : base("MON_ITEM_PROGRAMA_GESTOR", "ID_ITEM_PROGR_GESTOR")
        {
            Property(x => x.IdGestor).HasColumnName("ID_GESTOR_MONITOR").IsRequired();
            Property(x => x.IdItemPrograma).HasColumnName("ID_ITEM_PROGRAMA").IsRequired();
        }
    }
}
