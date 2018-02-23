using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Real_State
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
           name: "DefaultWithLanguage",
           url: "{language}/{controller}/{action}/{id}",
           defaults: new { language = "fa", controller = "Home", action = "Index", id = UrlParameter.Optional },
           constraints: new { language = "[a-z]{2}" }
                        );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional }
            );
        }
    }
}
