using Prodesp.Gsnet.Monitor.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Infra.Data.EF.Configurations
{
    public class MotivoAcaoConfiguration : EntityTypeConfiguration<MotivoAcao>
    {
        public MotivoAcaoConfiguration()
        {
            HasKey(k => k.Id);
            Property(x => x.Id)
                .HasColumnName("ID_MOTIVO_ACAO");
            Property(x => x.Nome)
                .HasColumnName("NM_MOTIVO_ACAO")
                .HasMaxLength(60)
                .IsRequired();            
            Property(x => x.Tipo)
               .HasColumnName("TP_MOTIVO_ACAO")
               .IsRequired();
            Property(x => x.PodeEditarJustificativa)
               .HasColumnName("ST_EDITA_JUSTIFICATIVA")
               .IsRequired();
            Property(x => x.JustificativaObrigatoria)
               .HasColumnName("ST_JUST_OBRIGATORIA")
               .IsRequired();
            Property(x => x.Descricao)
              .HasColumnName("DS_JUSTIFICATIVA")
              .HasMaxLength(300)
              .IsRequired();
            Property(x => x.DataInclusao)
              .HasColumnName("DAT_INCLUSAO")              
              .IsRequired();
            Property(x => x.DataAlteracao)
              .HasColumnName("DAT_ALTERACAO");                      
            Property(x => x.IdUsuarioInclusao)
              .HasColumnName("ID_USUARIO_INCLUSAO")
              .IsRequired();
            Property(x => x.FlagAtivo)
             .HasColumnName("FL_ATIVO")
             .IsRequired();
            
            Ignore(x => x.ValidationResult);
            Ignore(x => x.IsValid);
            ToTable("MON_MOTIVO_ACAO");
        }
    }
}
