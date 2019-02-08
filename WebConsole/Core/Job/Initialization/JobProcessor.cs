// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using WebConsole.Core.Entities;
using static WebConsole.Core.ApplicationConstants;

namespace WebConsole.Core.Job.Initialization
{
    public interface IJobProcessor
    {
        int Process(Process job, IDictionary<int, JobContent> all);
        int GetLimit();
    }

    public class JobProcessor : IJobProcessor
    {
        private readonly IJobContentProvider contentProvider;

        public JobProcessor(IJobContentProvider contentProvider)
        {
            this.contentProvider = contentProvider;
        }

        public int Process(Process job, IDictionary<int, JobContent> all)
        {
            job.Start();
            job.BeginOutputReadLine();
            job.BeginErrorReadLine();

            all[job.Id] = contentProvider.GetContent(job);
            return job.Id;
        }

        public int GetLimit()
        {
            var setting = ConfigurationManager.AppSettings[JobsLimitLiteral];
            var isSuccessful = int.TryParse(setting, out var limit);
            return isSuccessful ? limit : DefaultJobsLimit;
        }
    }
}