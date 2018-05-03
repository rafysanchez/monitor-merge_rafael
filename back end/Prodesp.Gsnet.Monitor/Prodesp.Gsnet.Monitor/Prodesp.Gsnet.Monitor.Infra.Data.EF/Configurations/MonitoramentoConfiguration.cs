using Prodesp.Gsnet.Monitor.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Infra.Data.EF.Configurations
{
    public class MonitoramentoConfiguration : BaseVigenciaTypeConfiguration<Monitoramento, long>
    {
        public MonitoramentoConfiguration() : base("MON_MONITORAMENTO", "ID_MONITORAMENTO")
        {
            Property(x => x.IdPrograma).HasColumnName("ID_PROGRAMA_MONITOR");
            Property(x => x.QuantidadeAlertas).HasColumnName("QT_ALERTAS");
            Property(x => x.DataMonitoramento).HasColumnName("DT_MONITORAMENTO");
            Property(x => x.TipoRegra).HasColumnName("TP_REGRA");
            HasMany(x => x.Itens)
                .WithRequired(x => x.Monitoramento)
                .HasForeignKey(x => x.IdMonitoramento);
        }
    }
}
