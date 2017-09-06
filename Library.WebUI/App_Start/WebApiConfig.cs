﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace Library.WebUI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(name: "DefaultApi", routeTemplate: "{controller}/{id}", defaults: new
            {
                id = RouteParameter.Optional
            });
        }
    }
}
