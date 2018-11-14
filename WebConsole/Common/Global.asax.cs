// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebConsole.Config;

namespace WebConsole
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.Register(RouteTable.Routes);

            ComponentsConfig.Register();
        }
    }
}
