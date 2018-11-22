// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
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
            ViewEnginesConfig.Register(ViewEngines.Engines);

            RouteConfig.Register(RouteTable.Routes);
            BundleConfig.Register(BundleTable.Bundles);

            var container = ComponentsConfig.Register();
            container.Resolve<IJobBufferHandler>().Init();
            finalizer = container.Resolve<IJobFinalizer>();
        }

        protected void Application_End()
        {
            finalizer.FinalAll();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            // TODO Add errors handler!!!
            var server = Context.Server;
            var error = server.GetLastError();
            var code = (error as HttpException)?.GetHttpCode() ?? 500;
            if (code != 404)
            {

            }
            server.ClearError();

            var response = Context.Response;
            response.Clear();
        }
    }
}
