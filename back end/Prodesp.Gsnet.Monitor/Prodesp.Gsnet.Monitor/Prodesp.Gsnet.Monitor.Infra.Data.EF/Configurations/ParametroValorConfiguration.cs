using Prodesp.Gsnet.Monitor.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Prodesp.Gsnet.Monitor.Infra.Data.EF.Configurations
{
    public class ParametroValorConfiguration : EntityTypeConfiguration<ParametroValor>
    {
        public ParametroValorConfiguration()
        {
            HasKey(k => k.IdParametroValor);
            Property(x => x.IdParametroValor)
                .HasColumnName("ID_PARAMETRO_VALOR");
            Property(x => x.IdParametro)
                .HasColumnName("ID_PARAMETRO")
                .IsRequired();
            Property(x => x.IdRegraMotor)
               .HasColumnName("ID_REGRA_MOTOR")
               .IsRequired();
            Property(x => x.VlParametro)
               .HasColumnName("VL_PARAMETRO")
               .IsRequired()
                .HasMaxLength(100);

            HasRequired(r => r.Regra)
                .WithMany()
                .HasForeignKey(x => x.IdRegraMotor);

            HasRequired(r => r.Parametro)
               .WithMany()
               .HasForeignKey(x => x.IdParametro);

            Ignore(x => x.ValidationResult);
            Ignore(x => x.IsValid);
            ToTable("MON_PARAMETRO_VALOR");
        }
    }
}
