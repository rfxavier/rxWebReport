﻿using rxWebReport.Models;
using System.Web.Http;

namespace rxWebReport
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // DEFAULTS TO JSON
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            // Web API configuration and services
            config.Filters.Add(new BasicAuthenticationAttribute());

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}
