// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System.Web.Mvc;

namespace WebConsole.Config
{
    public class ViewEnginesConfig
    {
        public static void Register(ViewEngineCollection engines)
        {
            engines.Clear();
            engines.Add(new WcViewEngine());
        }
    }
}