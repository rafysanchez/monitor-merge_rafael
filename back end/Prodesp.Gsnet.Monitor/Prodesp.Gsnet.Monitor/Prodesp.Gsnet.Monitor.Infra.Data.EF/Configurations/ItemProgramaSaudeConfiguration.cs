using Prodesp.Gsnet.Monitor.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Infra.Data.EF.Configurations
{
    public class ItemProgramaSaudeConfiguration : BaseVigenciaTypeConfiguration<ItemProgramaSaude,int>
    {
        public ItemProgramaSaudeConfiguration() : base("MON_ITEM_PROGRAMA_SAUDE", "ID_ITEM_PROGRAMA")
        {
            Property(x => x.IdProgramaSaude).HasColumnName("ID_PROGRAMA_MONITOR").IsRequired();
            Property(x => x.IdItem).HasColumnName("ID_ITEM_MONITOR").IsRequired();
            Property(x => x.CodigoGrupoRecurso).HasColumnName("CD_GRUPO_RECURSO");
        }
    }
}
