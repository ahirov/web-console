// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace WebConsole.Core.IoC
{
    public class WebShellModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(ApplicationStorage<>))
                   .As(typeof(IApplicationStorage<>))
                   .InstancePerLifetimeScope();

            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly)
                   .AsImplementedInterfaces()
                   .SingleInstance()
                   .PreserveExistingDefaults();
        }
    }
}