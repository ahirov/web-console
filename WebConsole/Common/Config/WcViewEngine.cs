// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System.Web.Mvc;

namespace WebConsole.Config
{
    public class WcViewEngine : RazorViewEngine
    {
        public WcViewEngine()
        {
            MasterLocationFormats = new[]
            {
                "~/Views/Workspace/Layout.cshtml"
            };

            ViewLocationFormats = new[]
            {
                "~/Views/{1}/{0}.cshtml"
            };

            PartialViewLocationFormats = new[]
            {
                "~/Views/Workspace/Partial/{0}.cshtml"
            };
        }
    }
}