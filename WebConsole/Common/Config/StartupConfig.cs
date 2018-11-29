// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;
using WebConsole.Areas.Job.Hubs;
using WebConsole.Config;
using WebConsole.Core.IoC;
using MvcDependencyResolver     = Autofac.Integration.Mvc.AutofacDependencyResolver;
using SignalRDependencyResolver = Autofac.Integration.SignalR.AutofacDependencyResolver;

[assembly: OwinStartup(typeof(StartupConfig))]
namespace WebConsole.Config
{
    public class StartupConfig
    {
        public static IContainer Container { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            BuildContainer();
            var config = new HubConfiguration 
            {
                Resolver = new SignalRDependencyResolver(Container)
            };
            DependencyResolver.SetResolver(new MvcDependencyResolver(Container));

            app.UseAutofacMiddleware(Container);
            app.UseAutofacMvc();
            app.MapSignalR("/signalr", config);
        }

        private static void BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<StreamHub>().ExternallyOwned();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModule<WebShellModule>();

            Container = builder.Build();
        }
    }
}