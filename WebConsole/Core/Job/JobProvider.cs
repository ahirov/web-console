// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System.Diagnostics;
using WebConsole.Core.Extensions;

namespace WebConsole.Core.Job
{
    public interface IJobProvider
    {
        Process GetJob(string location,
                       string args,
                       dynamic caller);
    }

    public class JobProvider : IJobProvider
    {
        public Process GetJob(string location,
                              string args,
                              dynamic caller)
        {
            var job = new Process
            {
                StartInfo = GetInfo(location, args),
                EnableRaisingEvents = true
            };
            job.OutputDataReceived += (sender, eventArgs) =>
            {
                var output = eventArgs.Data;
                if (output.HasValue())
                    caller.read(job.Id, output);
            };
            job.Exited += (sender, eventArgs) => caller.stop(job.Id);
            return job;
        }

        private static ProcessStartInfo GetInfo(string location, string args)
        {
            return new ProcessStartInfo
            {
                FileName  = location,
                Arguments = args,
                RedirectStandardInput  = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow  = true
            };
        }
    }
}