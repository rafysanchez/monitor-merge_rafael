using System;


namespace Prodesp.Monitor.DAL.DataBase.Util
{
    public class ConnectionStringToken
    {
        public string Saltkey { get; set; }
        public string ConnectionString { get; set; }

        public static ConnectionStringToken Parse(string base64ConnectionString)
        {
            try
            {
                var bytes = Convert.FromBase64String(base64ConnectionString);
                var json = System.Text.Encoding.UTF8.GetString(bytes);
                var obj = Prodesp.Gsnet.Framework.HelperJSON.Deserialize<ConnectionStringToken>(json);
                var connectionString = Prodesp.Gsnet.Framework.HelperSecurity.Decrypt(obj.ConnectionString, obj.Saltkey);
                return new ConnectionStringToken
                {
                    Saltkey = obj.Saltkey,
                    ConnectionString = connectionString
                };
            }
            catch
            {
                return null;
            }
        }

        public override string ToString()
        {
            try
            {
                var securityConn = Prodesp.Gsnet.Framework.HelperSecurity.Encrypt(this.ConnectionString, this.Saltkey);
                var conn = new ConnectionStringToken
                {
                    Saltkey = this.Saltkey,
                    ConnectionString = securityConn
                };
                var json = Prodesp.Gsnet.Framework.HelperJSON.Serialize(conn);
                var bytes = System.Text.Encoding.UTF8.GetBytes(json);
                return Convert.ToBase64String(bytes);
            }
            catch
            {
                return string.Empty;
            }
        }
    }

}
