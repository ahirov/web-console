// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System;
using System.Diagnostics;

namespace WebConsole.Core.Job.Initialization
{
    public interface IJobParamsProvider
    {
        ProcessStartInfo GetParams(string location, string args);
    }

    public class JobParamsProvider : IJobParamsProvider
    {
        public ProcessStartInfo GetParams(string location, string args)
        {
            return new ProcessStartInfo
            {
                FileName = Environment.ExpandEnvironmentVariables(location),
                Arguments = args,
                RedirectStandardInput  = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow  = true
            };
        }
    }
}