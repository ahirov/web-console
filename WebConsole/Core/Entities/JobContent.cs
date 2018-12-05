// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System.Diagnostics;

namespace WebConsole.Core.Entities
{
    public class JobContent
    {
        public JobDescription Description { get; set; }
        public Process Process { get; set; }
    }
}