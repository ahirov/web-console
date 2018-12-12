// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System;
using System.Diagnostics;
using WebConsole.Core.Extensions;

namespace WebConsole.Core.Job.Initialization
{
    public interface IJobProvider
    {
        Process GetJob(string location,
                       string args,
                       dynamic caller);
    }

    public class JobProvider : IJobProvider
    {
        private readonly IJobParamsProvider paramsProvider;

        public JobProvider(IJobParamsProvider paramsProvider)
        {
            this.paramsProvider = paramsProvider;
        }

        public Process GetJob(string location,
                              string args,
                              dynamic caller)
        {
            var job = new Process
            {
                StartInfo = paramsProvider.GetParams(location, args),
                EnableRaisingEvents = true
            };
            job.OutputDataReceived += (sender, eventArgs) =>
            {
                var output = eventArgs.Data;
                if (output.HasValue())
                    caller.read(job.Id, output);
            };
            job.Exited += (sender, eventArgs) =>
            {
                try
                {
                    if (sender is Process process
                     && process.ExitCode == 0)
                        caller.stop(job.Id);
                }
                catch (Exception)
                {
                    // ignored
                }
            };
            job.ErrorDataReceived += (sender, eventArgs) =>
            {
                var output = eventArgs.Data;
                if (output.HasValue())
                    caller.error(job.Id, output);
            };
            return job;
        }
    }
}