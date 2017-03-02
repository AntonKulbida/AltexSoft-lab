﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ASP1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            /*
            routes.MapRoute(
                name: "Math",
                url: "Math/{action}"
                );
                */
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            /*
            routes.MapRoute(
                name: "Add",
                url: "{controller}/{action}",
                defaults: new { controller = "Math", action = "Add" }
            );

            routes.MapRoute(
                name: "Sub",
                url: "{controller}/{action}",
                defaults: new { controller = "Math", action = "Sub" }
            );

            routes.MapRoute(
                name: "Mul",
                url: "{controller}/{action}",
                defaults: new { controller = "Math", action = "Mul" }
            );

            routes.MapRoute(
                name: "Div",
                url: "{controller}/{action}",
                defaults: new { controller = "Math", action = "Div" }
            );

            routes.MapRoute(
                name: "Math",
                url: "{controller}/{action}",
                defaults: new { controller = "Math", action = "Index" }
            );*/

        }
    }
}