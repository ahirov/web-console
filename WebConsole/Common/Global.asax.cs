// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using WebConsole.Config;
using WebConsole.Core.Job;

namespace WebConsole
{
    public class MvcApplication : HttpApplication
    {
        private IJobFinalizer finalizer;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.Register(RouteTable.Routes);

            var container = ComponentsConfig.Register();
            finalizer = container.Resolve<IJobFinalizer>();
        }

        protected void Application_End()
        {
            finalizer.Final();
        }
    }
}
