using Prodesp.Gsnet.Monitor.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Infra.Data.EF.Configurations
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            HasKey(x => x.Id);           
            Property(x => x.Id)
                .HasColumnName("");
            Property(x => x.Login)
                .HasColumnName("CD_LOGIN")
                .HasMaxLength(11)
                .IsRequired();
            Property(x => x.FlagAcessoBloqueio)
                .HasColumnName("FL_ACESSO_BLOQUEIO")
                .HasMaxLength(1)
                .IsRequired();
            Property(x => x.Nome)
                .HasColumnName("NM_USUARIO")
                .HasMaxLength(40)
                .IsRequired();
            Property(x => x.Senha)
                .HasColumnName("CD_SENHA")
                .HasMaxLength(12)
                .IsRequired();
            Property(x => x.Codigo)
                .HasColumnName("CD_USUARIO")
                .HasMaxLength(15)
                .IsRequired();
            Property(x => x.FlagUsuarioSistema)
                .HasColumnName("FL_USUARIO_SISTEMA")
                .HasMaxLength(1)
                .IsRequired();            
            Property(x => x.DataAlteracao).IsRequired();
            Property(x => x.DataInclusao).IsRequired();
            HasRequired(x => x.Gestor)
                .WithMany()
                .HasForeignKey(x => x.IdGestor);
            ToTable("GSS_USUARIO");
        }
    }
}
