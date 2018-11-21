// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System.Xml.Linq;

namespace WebConsole.Core.Extensions
{
    public static class XObjectExtensions
    {
        public static bool HasValue(this XObject xObject)
        {
            return xObject != null;
        }
    }
}