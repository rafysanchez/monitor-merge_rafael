using Prodesp.Gsnet.Monitor.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Infra.Data.EF.Configurations
{
    public class ItemMonitoramentoConfiguration : EntityTypeConfiguration<ItemMonitoramento>
    {
        public ItemMonitoramentoConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("ID_ITEM_MONITORAMENTO");
            Property(x => x.IdItemProgramaGestor).HasColumnName("ID_ITEM_PROGR_GESTOR");
            Property(X => X.IdMonitoramento).HasColumnName("ID_MONITORAMENTO");
            Property(x => x.QuantidadeSaldoDisponivel).HasColumnName("QT_SALDO_DISPONIVEL");
            Property(x => x.QuantidadeDiasAutonomia).HasColumnName("QT_AUTONOMIA_DIAS");
            Property(x => x.QuantidadeUltimaFatura).HasColumnName("QT_ULTIMA_FATURA");
            Property(x => x.DataUltimaFatura).HasColumnName("DT_ULTIMA_FATURA");
            Property(x => x.QuantidadeUltimoEmpenho).HasColumnName("QT_ULTIMO_EMPENHO");
            Property(x => x.DataUltimoEmpenho).HasColumnName("DT_ULTIMO_EMPENHO");
            Property(x => x.QuantidadeUltimoConsumo).HasColumnName("QT_ULTIMO_CONSUMO");
            Property(x => x.DataUltimoConsumo).HasColumnName("DT_ULTIMO_CONSUMO");
            Property(x => x.TipoConsumo).HasColumnName("TP_CONSUMO");
            Property(x => x.QuantidadeConsumo).HasColumnName("QT_CONSUMO");
            Property(x => x.TipoRegra).HasColumnName("TP_REGRA");

            HasRequired(x => x.Monitoramento)
                .WithMany()
                .HasForeignKey(f => f.IdMonitoramento);
            ToTable("MON_ITEM_MONITORAMENTO");

            Ignore(x => x.ValidationResult);
            Ignore(x => x.IsValid);
            Ignore(x => x.ItemProgramaGestor);
            Ignore(x => x.Usuario);
        }
    }
}
