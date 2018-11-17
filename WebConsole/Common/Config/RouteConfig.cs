// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System.Web.Mvc;
using System.Web.Routing;

namespace WebConsole.Config
{
    public class RouteConfig
    {
        public static void Register(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute("Default",
                            "{controller}/{action}/{id}",
                            GetDefaults()
            );
        }

        private static object GetDefaults()
        {
            return new
            {
                controller = "Home",
                action = "Index",
                id = UrlParameter.Optional
            };
        }
    }
}
