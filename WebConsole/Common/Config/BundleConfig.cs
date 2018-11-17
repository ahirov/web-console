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
            Include("~/Scripts/global/", js);
            Include("~/Scripts/job/", js);

            var css = new StyleBundle("~/bundles/css");
            bundles.Add(css);
            Include("~/Styles/global/", css);
            Include("~/Styles/io/", css);
        }

        private static void Include(string path, Bundle bundle)
        {
            var extension = bundle is ScriptBundle
                ? "*.js"
                : bundle is StyleBundle
                    ? "*.css"
                    : null;
            if (extension != null)
                bundle.IncludeDirectory(path, extension, true);
        }
    }
}