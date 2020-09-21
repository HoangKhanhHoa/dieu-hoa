using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace idn.AnPhu.Website
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //Routes are registered using: Portal.Web.Extensions.RoutingHelper
            //Routes are configured at: Config\Routes.config

            //RoutingHelper.RegisterRoutes(RouteTable.Routes, RouteMappingConfiguration.Current);

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    "front_end_gioi_thieu",
            //    "{culture}/gioi-thieu",
            //    new { culture = "vi", controller = "Home", action = "About", id = UrlParameter.Optional },
            //    new[] { "idn.AnPhu.Website.Controllers" }
            //);

            //routes.MapRoute(
            //    "front_end_lien_he",
            //    "{culture}/lien-he",
            //    new { culture = "vi", controller = "Home", action = "Contact", id = UrlParameter.Optional },
            //    new[] { "idn.AnPhu.Website.Controllers" }
            //);

            //routes.MapRoute(
            //    "Default",
            //    "{culture}/{controller}/{action}/{id}",
            //    new { culture = "vi", controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    new[] { "idn.AnPhu.Website.Controllers" }
            //);

            routes.MapRoute(
             "NetAdvImage",
             "{scriptPath}/tinymce/plugins/netadvimage/{action}",
             new { controller = "NetAdvImage" }
            );

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "idn.AnPhu.Website.Controllers" }
            );
        }
    }
}
