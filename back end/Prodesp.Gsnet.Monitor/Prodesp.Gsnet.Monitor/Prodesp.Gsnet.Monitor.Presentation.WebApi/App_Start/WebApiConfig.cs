using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Routing;

namespace Prodesp.Gsnet.Monitor.Presentation.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //cors
            config.EnableCors();
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            // Adding formatter for Json   
            config.Formatters.JsonFormatter.MediaTypeMappings.Add(
                new QueryStringMapping("type", "json", new MediaTypeHeaderValue("application/json")));

            // Adding formatter for XML   
            config.Formatters.XmlFormatter.MediaTypeMappings.Add(
                new QueryStringMapping("type", "xml", new MediaTypeHeaderValue("application/xml")));

            
            config.Routes.MapHttpRoute(
                name: "DefaultApi2",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );        
        }
    }
}
