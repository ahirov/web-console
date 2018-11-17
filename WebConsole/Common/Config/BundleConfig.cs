// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System.Web.Optimization;

namespace WebConsole.Config
{
    public class BundleConfig
    {
        public static void Register(BundleCollection bundles)
        {
            var js = new ScriptBundle("~/bundles/js");
            bundles.Add(js);
            js.IncludeDirectory("~/Scripts/global/", "*.js", true);
            js.IncludeDirectory("~/Scripts/job/", "*.js", true);

            var css = new StyleBundle("~/bundles/css");
            bundles.Add(css);
            css.IncludeDirectory("~/Styles/global/", "*.css", true);
        }
    }
}