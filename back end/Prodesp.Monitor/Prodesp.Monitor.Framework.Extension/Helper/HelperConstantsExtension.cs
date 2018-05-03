using Prodesp.Gsnet.Framework;

namespace Prodesp.Monitor.Framework.Extension.Helper
{
    public class HelperConstantsExtension
    {
        public static string ConnectionStringGSNet
        {
            get { return HelperSettings.ReadString("ConnectionStrings.GSNET"); }
        }


        public static string GsnetEstoqueSchema
        {
            get { return HelperSettings.ReadString("GSNET.ESTOQUE.SCHEMA"); }
        }

        public static string UrlTodo
        {
            get { return HelperSettings.ReadString("Url.Todo"); }
        }

    }
}
