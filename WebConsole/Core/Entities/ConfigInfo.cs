// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System.Collections.Generic;

namespace WebConsole.Core.Entities
{
    public class ConfigInfo
    {
        public string JobsLimit { get; set; }
        public List<JobInfo> Jobs { get; set; }
    }
}