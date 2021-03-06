﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace VidlyNew
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            ///Example of Custom Routing
            //routes.MapRoute(
            //    "MoviesByReleaseDate",
            //    "Movies/Released/{year}/{month}",
            //    new { controller = "Movies", action = "ByReleaseDate" },
            //    new { year ="2015|2016", month=@"\d{2}"}
            //);

            routes.MapHttpRoute(
                name: "API Default",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
