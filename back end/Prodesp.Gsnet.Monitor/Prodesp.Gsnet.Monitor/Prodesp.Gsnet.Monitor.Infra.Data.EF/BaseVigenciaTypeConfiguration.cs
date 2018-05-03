using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Domain.Validacoes;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodesp.Gsnet.Monitor.Infra.Data.EF
{
    public class BaseVigenciaTypeConfiguration<TEntity,TKeyType> : BaseTypeIdConfiguration<TEntity,TKeyType>
        where TEntity : class, IEntityKey<TKeyType>, IVigencia, ISelfValidation
        where TKeyType : struct
    {
        /// <summary>
        /// Cria uma nova instacia de BaseTypeConfiguration
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="idColumnName"></param>
        public BaseVigenciaTypeConfiguration(string tableName, string idColumnName) : base(tableName, idColumnName)
        {
            // define a chave primaria da tabela
            HasKey(x => x.Id);
            // mapeia o campo conforme o nome no banco de dados
            Property(x => x.Id).HasColumnName(idColumnName);

            Property(x => x.DataInicioVigencia).HasColumnName("DT_INICIO_VIGENCIA").IsRequired();
            Property(x => x.DataFimVigencia).HasColumnName("DT_FIM_VIGENCIA");
            Property(x => x.FlagAtivo).HasColumnName("FL_ATIVO").IsRequired();
            Ignore(x => x.ValidationResult);
            Ignore(x => x.IsValid);
            // mapeia a tabela conforme nome no banco
            ToTable(tableName);
        }
    }
}
