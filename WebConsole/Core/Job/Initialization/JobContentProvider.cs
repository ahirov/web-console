// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System.Diagnostics;
using WebConsole.Core.Entities;

namespace WebConsole.Core.Job.Initialization
{
    public interface IJobContentProvider
    {
        JobContent GetContent(Process job);
    }

    public class JobContentProvider : IJobContentProvider
    {
        public JobContent GetContent(Process job)
        {
            return new JobContent
            {
                Process = job,
                Description = GetDescription(job)
            };
        }

        private static JobDescription GetDescription(Process job)
        {
            return new JobDescription
            {
                Name = $"{job.ProcessName}.exe",
                StartTime = job.StartTime.ToString("g")
            };
        }
    }
}