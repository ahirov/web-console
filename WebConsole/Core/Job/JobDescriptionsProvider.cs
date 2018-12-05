// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System.Collections.Generic;
using WebConsole.Core.Entities;

namespace WebConsole.Core.Job
{
    public interface IJobDescriptionsProvider
    {
        List<JobDescription> GetDescriptions();
    }

    public class JobDescriptionsProvider : IJobDescriptionsProvider
    {
        private readonly IJobBufferHandler buffer;

        public JobDescriptionsProvider(IJobBufferHandler buffer)
        {
            this.buffer = buffer;
        }

        public List<JobDescription> GetDescriptions()
        {
            var descriptions = new List<JobDescription>();
            buffer.RunAll(process =>
            {
                descriptions.Add(new JobDescription
                {
                    Name      = process.MainModule.ModuleName,
                    StartTime = process.StartTime.ToString("F")
                });
            });
            return descriptions;
        }
    }
}