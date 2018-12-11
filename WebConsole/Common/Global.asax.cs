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
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            ViewEnginesConfig.Register(ViewEngines.Engines);

            RouteConfig.Register(RouteTable.Routes);
            BundleConfig.Register(BundleTable.Bundles);
        }

        protected void Application_End()
        {
            StartupConfig.Container.Resolve<IJobFinalizer>().FinalAll();
            StartupConfig.CleanUpTimer.Stop();
            StartupConfig.CleanUpTimer.Dispose();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var error = Server.GetLastError();
            var isCriticalError = (error as HttpException)?.GetHttpCode() != 404;
            if (isCriticalError)
                Session["error"] = error;
            Server.ClearError();

            var response = Context.Response;
            response.Clear();

            if (Context.CurrentHandler is MvcHandler handler
             && handler.RequestContext.HttpContext.Request.IsAjaxRequest())
                response.StatusCode = 400;
            else
            {
                var action = isCriticalError
                    ? "Critical"
                    : "PageNotFound";
                response.Redirect($"/Error/{action}");
            }
        }
    }
}