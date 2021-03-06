﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
namespace SortingAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors(new EnableCorsAttribute("http://localhost:4200", headers: "*", methods: "*"));
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "SortingAPI",
                routeTemplate: "api/values"
                //defaults: new { string id: RouteParameter.Optional }
            );
        }
    }
}
