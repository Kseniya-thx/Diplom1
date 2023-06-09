﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Diplom1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "AllQuestion",
                url: "All",
                defaults: new { controller = "Bases", action = "All" }
            );

            routes.MapRoute(
              name: "AboutCompany",
              url: "About",
              defaults: new { controller = "Bases", action ="About"}
              ) ;


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Bases", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
