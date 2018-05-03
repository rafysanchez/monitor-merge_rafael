using Prodesp.Gsnet.Monitor.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Infra.Data.EF.Configurations
{
    public class JustificativaConfiguration : BaseTypeIdConfiguration<Justificativa, int>
    {
        public JustificativaConfiguration() : base("MON_JUSTIFICATIVA", "ID_JUSTIFICATIVA")
        {
            Property(x => x.IdItemMonitoramento).HasColumnName("ID_ITEM_MONITORAMENTO").IsRequired();
            Property(x => x.DataAlteracao).HasColumnName("DT_ALTERACAO");
            Property(x => x.DataInclusao).HasColumnName("DT_INCLUSAO").IsRequired();
            Property(x => x.DataJustificativa).HasColumnName("DT_JUSTIFICATIVA").IsRequired();
            Property(x => x.IdAcao).HasColumnName("ID_ACAO").IsRequired();
            Property(x => x.IdUsuario).HasColumnName("ID_USUARIO");
            Property(x => x.IdMotivo).HasColumnName("ID_MOTIVO").IsRequired();
            Property(x => x.IdJustificador).HasColumnName("ID_JUSTIFICADOR").IsRequired();
            Property(x => x.MotivoJustificativa).HasColumnName("DS_COMPL_MOTIVO");
            Property(x => x.AcaoJustificativa).HasColumnName("DS_COMPL_ACAO");
            HasRequired(x => x.Motivo).WithMany().HasForeignKey(x => x.IdMotivo);
            HasRequired(x => x.Acao).WithMany().HasForeignKey(x => x.IdAcao);
            Ignore(x => x.IdItemGsnet);
            Ignore(x => x.IdGestorMonitor);
        }
    }
}
