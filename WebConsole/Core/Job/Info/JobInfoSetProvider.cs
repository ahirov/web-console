// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System;
using System.Collections.Generic;
using System.Linq;
using WebConsole.Core.Entities;
using WebConsole.Core.Job.Config;

namespace WebConsole.Core.Job.Info
{
    public interface IJobInfoSetProvider
    {
        List<JobInfo> GetAll(List<Type> customJobs);
    }

    public class JobInfoSetProvider : IJobInfoSetProvider
    {
        private readonly IJobSetConfigReader configReader;
        private readonly IJobInfoProvider infoProvider;

        public JobInfoSetProvider(IJobSetConfigReader configReader,
                                  IJobInfoProvider infoProvider)
        {
            this.configReader = configReader;
            this.infoProvider = infoProvider;
        }

        public List<JobInfo> GetAll(List<Type> customJobs)
        {
            var infos = configReader.Read();
            var customInfos = customJobs.Select(infoProvider.Get);

            infos.AddRange(customInfos);
            return infos.OrderBy(info => info.FullName).ToList();
        }
    }
}