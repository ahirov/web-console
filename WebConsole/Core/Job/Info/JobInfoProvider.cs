// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System;
using System.Collections.Generic;
using System.Linq;
using WebConsole.Core.Entities;
using WebConsole.Core.Job.IO;

namespace WebConsole.Core.Job.Info
{
    public interface IJobInfoProvider
    {
        List<JobInfo> GetJobInfoSet(List<Type> customJobs);
    }

    public class JobInfoProvider : IJobInfoProvider
    {
        private readonly IJobConfigReader configReader;

        public JobInfoProvider(IJobConfigReader configReader)
        {
            this.configReader = configReader;
        }

        public List<JobInfo> GetJobInfoSet(List<Type> customJobs)
        {
            var jobs = configReader.ReadJobs();
            jobs.AddRange(Get(customJobs));
            return jobs.OrderBy(info => info.Name).ToList();
        }

        private static List<JobInfo> Get(IEnumerable<Type> jobs)
        {
            return jobs.Select(type => new JobInfo
            {
                Name     = type.FullName,
                Location = type.Assembly.Location
            }).ToList();
        }
    }
}