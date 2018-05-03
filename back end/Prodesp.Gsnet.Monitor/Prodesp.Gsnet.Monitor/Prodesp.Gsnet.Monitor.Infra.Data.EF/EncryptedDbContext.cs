//using Oracle.ManagedDataAccess.Client;
//using Prodesp.Gsnet.Framework;
//using System;
//using System.Collections.Generic;
//using System.Data.Common;
//using System.Data.Entity;
//using System.Data.Entity.Core.EntityClient;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;

//namespace Prodesp.Gsnet.Monitor.Infra.Data.EF
//{
//    / <summary>
//    / 
//    / </summary>
//    public abstract class EncryptedDbContext : DbContext
//    {
//        public readonly string Schema;
//        public EncryptedDbContext(string encryptedConnectionString, string defaultSchema = "") : base(ParseConnection(encryptedConnectionString), false)
//        {
//            this.Schema = defaultSchema;
//        }
//        / <summary>
//        / Aplica as configurações ao DbContext as configurações adicionais
//        / antes que o mesmo seja bloqueado.
//        / </summary>
//        / <param name = "modelBuilder" ></ param >
//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//            this.SetDefaultSchema(modelBuilder);
//            this.ApplyConfiguration(modelBuilder);
//        }
//        / <summary>
//        / Converte a connectionString criptografada em uma instancia de OracleConnection
//        / </summary>
//        / <param name = "encryptedConnectionString" > connectionString criptografada</param>
//        / <returns>nova instancia de OracleConnection</returns>
//        private static OracleConnection ParseConnection(string encryptedConnectionString)
//        {
//            string decryptedConnectionString = DecryptConnectionString(encryptedConnectionString);
//            OracleConnection con = new OracleConnection(encryptedConnectionString);
//            return con;
//        }
//        / <summary>
//        / Descriptografa a connectionString que sera usada no conxtexto
//        / </summary>
//        / <param name = "encryptedConnectionString" > connectionString criptografada</param>
//        / <returns></returns>
//        public static string DecryptConnectionString(string encryptedConnectionString)
//        {
//            var connectionStringToken = ConnectionStringToken.Parse(encryptedConnectionString);
//            return connectionStringToken?.ConnectionString;
//        }
//        / <summary>
//        / Define o schema padrão da conexão
//        / </summary>
//        / <param name = "modelBuilder" ></ param >
//        private void SetDefaultSchema(DbModelBuilder modelBuilder)
//        {
//            if (string.IsNullOrEmpty(this.Schema))
//                return;
//            modelBuilder.HasDefaultSchema(this.Schema);
//        }

//        / <summary>
//        / Aplica configurações adicionais, como os mapeamentos de entidades, coonvenções e etc.
//        / </summary>
//        / <param name = "modelBuilder" ></ param >
//        public abstract void ApplyConfiguration(DbModelBuilder modelBuilder);
//    }
//    public class ConnectionStringToken
//    {
//        public string Saltkey { get; set; }
//        public string ConnectionString { get; set; }

//        public static ConnectionStringToken Parse(string base64ConnectionString)
//        {
//            try
//            {
//                var bytes = Convert.FromBase64String(base64ConnectionString);
//                var json = System.Text.Encoding.UTF8.GetString(bytes);
//                var obj = HelperJSON.Deserialize<ConnectionStringToken>(json);
//                var connectionString = HelperSecurity.Decrypt(obj.ConnectionString, obj.Saltkey);
//                return new ConnectionStringToken
//                {
//                    Saltkey = obj.Saltkey,
//                    ConnectionString = connectionString
//                };
//            }
//            catch
//            {
//                return null;
//            }
//        }

//        public override string ToString()
//        {
//            try
//            {
//                var securityConn = HelperSecurity.Encrypt(this.ConnectionString, this.Saltkey);
//                var conn = new ConnectionStringToken
//                {
//                    Saltkey = this.Saltkey,
//                    ConnectionString = securityConn
//                };
//                var json = HelperJSON.Serialize(conn);
//                var bytes = System.Text.Encoding.UTF8.GetBytes(json);
//                return Convert.ToBase64String(bytes);
//            }
//            catch
//            {
//                return string.Empty;
//            }
//        }
//    }
//}

