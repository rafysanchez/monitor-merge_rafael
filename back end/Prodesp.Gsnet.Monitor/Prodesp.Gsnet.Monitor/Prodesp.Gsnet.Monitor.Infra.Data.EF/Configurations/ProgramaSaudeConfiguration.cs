using Prodesp.Gsnet.Monitor.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Infra.Data.EF.Configurations
{
  public  class ProgramaSaudeConfiguration : EntityTypeConfiguration<ProgramaSaude>
    {
        public ProgramaSaudeConfiguration()
        {
            HasKey(k => k.IdProgramaSaude);

            Property(x => x.IdProgramaSaude)
                .HasColumnName("ID_PROGRAMA_MONITOR");

            Property(x => x.IdGsnet)
                .HasColumnName("ID_PROGRAMA_GSNET")
                .IsRequired();

            Property(x => x.NomePrograma)
               .HasColumnName("NM_PROGRAMA")
               .IsRequired();

            Property(x => x.CodigoProgramaSaude)
               .HasColumnName("CD_PROGRAMA_SAUDE")
               .IsRequired();

            Property(x => x.DataInicioVigencia)
               .HasColumnName("DT_INICIO_VIGENCIA")
               .IsRequired();

            Property(x => x.DataFimVigencia)
              .HasColumnName("DT_FIM_VIGENCIA");
              
             
            Property(x => x.FlagAtivo)
              .HasColumnName("FL_ATIVO")
              .IsRequired();
            Property(x => x.IdUsuario)
              .HasColumnName("ID_USUARIO");
            

            Ignore(x => x.ValidationResult);
            Ignore(x => x.IsValid);
            ToTable("MON_PROGRAMA_SAUDE");
        }
    }
}
