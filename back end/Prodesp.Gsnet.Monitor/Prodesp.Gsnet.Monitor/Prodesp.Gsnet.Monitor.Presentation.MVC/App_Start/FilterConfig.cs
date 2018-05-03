using System.Web;
using System.Web.Mvc;

namespace Prodesp.Gsnet.Monitor.Presentation.MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
