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
    public class BaseTypeIdConfiguration<TEntity, TKeyType> : EntityTypeConfiguration<TEntity>
        where TEntity : class, IEntityKey<TKeyType>, ISelfValidation
        where TKeyType : struct
    {
        /// <summary>
        /// Cria uma nova instacia de BaseTypeConfiguration
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="idColumnName"></param>
        public BaseTypeIdConfiguration(string tableName, string idColumnName)
        {
            // define a chave primaria da tabela
            HasKey(x => x.Id);
            // mapeia o campo conforme o nome no banco de dados
            Property(x => x.Id).HasColumnName(idColumnName);
            // mapeia a tabela conforme nome no banco
            ToTable(tableName);
            Ignore(x => x.ValidationResult);
            Ignore(x => x.IsValid);
        }
    }
}
