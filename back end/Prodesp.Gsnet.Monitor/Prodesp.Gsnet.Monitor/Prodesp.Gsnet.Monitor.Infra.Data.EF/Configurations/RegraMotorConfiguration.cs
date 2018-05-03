using Prodesp.Gsnet.Monitor.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Infra.Data.EF.Configurations
{
    public class RegraMotorConfiguration : EntityTypeConfiguration<RegraMotor>
    {
        public RegraMotorConfiguration()
        {
            HasKey(k => k.IdRegraMotor);
            Property(x => x.IdRegraMotor)
                .HasColumnName("ID_REGRA_MOTOR");

            Property(x => x.IdProgramaMotor)
                .HasColumnName("ID_PROGRAMA_MONITOR")
                .IsRequired();

            Property(x => x.TpParametro)
               .HasColumnName("TP_PARAMETRO");


            Property(x => x.IdUsuario)
               .HasColumnName("ID_USUARIO");


            Property(x => x.DataInicioVigencia)
               .HasColumnName("DT_INICIO_VIGENCIA")
               .IsRequired();

            Property(x => x.DataFimVigencia)
              .HasColumnName("DT_FIM_VIGENCIA")
              .IsRequired();

            Property(x => x.FlagAtivo)
              .HasColumnName("FL_ATIVO");

            Property(x => x.FlStatus)
              .HasColumnName("FL_STATUS");

            HasRequired(p => p.PogramaSaude).WithMany().HasForeignKey(f => f.IdProgramaMotor);

            Ignore(x => x.ValidationResult);
            Ignore(x => x.IsValid);

            ToTable("MON_REGRA_MOTOR");
        }
    }
}
