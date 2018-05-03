using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Prodesp.Gsnet.Monitor.Presentation.MVC
{
    public class RouteConfig
    {      
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
                   
            routes.MapRoute(
                name: "Login",
                url: "Rbac/Login",
                defaults: new { controller = "Account", action = "Login"}
            );
            routes.MapRoute(
                name: "Callback",
                url: "Rbac/Callback",
                defaults: new { controller = "Account", action = "Callback" }
            );
            routes.MapRoute(
                name: "Error",
                url: "Error/{id}/{status}",
                defaults: new { controller = "ErrorHandler", action = "HandleError", id = UrlParameter.Optional, status = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "angular",
                url: "{*anything}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });


        }
    }
}
