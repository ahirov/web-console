// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System;
using System.Collections.Generic;
using System.Linq;
using WebConsole.Core.Entities.Configuration;

namespace WebConsole.Core.Job.Configuration
{
    public interface IConfigInfoProcessor
    {
        ConfigurationInfo Process(List<Type> customJobs);
    }

    public class ConfigInfoProcessor : IConfigInfoProcessor
    {
        private readonly IConfigInfoReader configInfoReader;
        private readonly IJobInfoProcessor jobInfoProcessor;

        public ConfigInfoProcessor(IConfigInfoReader configInfoReader,
                                  IJobInfoProcessor jobInfoProcessor)
        {
            this.configInfoReader = configInfoReader;
            this.jobInfoProcessor = jobInfoProcessor;
        }

        public ConfigurationInfo Process(List<Type> customJobs)
        {
            var config = configInfoReader.Read();
            var jobs = customJobs.Select(jobInfoProcessor.Process);

            config.Jobs.AddRange(jobs);
            return config;
        }
    }
}