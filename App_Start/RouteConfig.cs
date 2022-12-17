using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           
            // routes.MapRoute(
            //    name: "Test",
            //    url: "test/{action}",
            //    defaults: new { controller = "Test", action = "PrintMessage" }
            //);
            routes.MapRoute(
                name: "Entrance",
                url: "{Entrance}",
                defaults: new { controller = "Entrance", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Timetable",
                url: "{Timetable}",
                defaults: new { controller = "Timetable", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
