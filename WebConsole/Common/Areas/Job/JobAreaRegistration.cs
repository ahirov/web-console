// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System.Web.Mvc;

namespace WebConsole.Areas.Job
{
    public class JobAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Job";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute("Job_default",
                             "Job/{controller}/{action}/{id}",
                             GetDefaults()
            );
        }

        private static object GetDefaults()
        {
            return new
            {
                id = UrlParameter.Optional
            };
        }
    }
}