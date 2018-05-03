using Prodesp.Gsnet.Monitor.Domain.Entidades;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Keys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Infra.Data.EF.Configurations
{
    public class GestorConfiguration : BaseVigenciaTypeConfiguration<Gestor, int>
    {
        public GestorConfiguration() : base("MON_GESTORES", "ID_GESTOR_MONITOR")
        {
            Property(x => x.IdGsnet).HasColumnName("ID_GESTOR_GSNET").IsRequired();
            Property(x => x.Nome).HasColumnName("NM_GESTOR").IsRequired();
            Property(x => x.Sigla).HasColumnName("SG_GESTOR").IsRequired();
        }
    }
}
