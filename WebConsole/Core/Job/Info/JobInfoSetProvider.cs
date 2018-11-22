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
    public interface IJobInfoSetProvider
    {
        List<JobInfo> GetAll(List<Type> customJobs);
    }

    public class JobInfoSetProvider : IJobInfoSetProvider
    {
        private readonly IJobSetConfigReader setConfigReader;
        private readonly IJobInfoProvider infoProvider;

        public JobInfoSetProvider(IJobSetConfigReader setConfigReader,
                                  IJobInfoProvider infoProvider)
        {
            this.setConfigReader = setConfigReader;
            this.infoProvider = infoProvider;
        }

        public List<JobInfo> GetAll(List<Type> customJobs)
        {
            var jobs = setConfigReader.Read();
            jobs.AddRange(customJobs.Select(infoProvider.Get));
            return jobs.OrderBy(info => info.FullName).ToList();
        }
    }
}