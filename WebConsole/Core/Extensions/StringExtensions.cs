// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

namespace WebConsole.Core.Extensions
{
    public static class StringExtensions
    {
        public static bool HasValue(this string input)
        {
            return !string.IsNullOrEmpty(input);
        }
    }
}