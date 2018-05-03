using Prodesp.Gsnet.Monitor.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Infra.Data.EF.Configurations
{
    public class ParametroConfiguration : EntityTypeConfiguration<Parametro>
    {
        public ParametroConfiguration()
        {
            HasKey(k => k.Id);

            Property(x => x.Id)
                .HasColumnName("ID_PARAMETRO");

            Property(x => x.IdUsuario)
                .HasColumnName("ID_USUARIO");

            Property(x => x.CdParametro)
               .HasColumnName("CD_PARAMETRO").IsRequired();

            Property(x => x.TpDadoParametro)
               .HasColumnName("TP_DADO_PARAMETRO").IsRequired();

            Property(x => x.DsParametro)
               .HasColumnName("DS_PARAMETRO");

            Property(x => x.DtInicioVigencia)
              .HasColumnName("DT_INICIO_VIGENCIA").IsRequired();

            Property(x => x.DtFimVigencia)
            .HasColumnName("DT_FIM_VIGENCIA");

            Property(x => x.FlagAtivo)
             .HasColumnName("FL_ATIVO").IsRequired();

            Ignore(x => x.ValidationResult);
            Ignore(x => x.IsValid);
            ToTable("MON_PARAMETRO");
        }

    }
}
