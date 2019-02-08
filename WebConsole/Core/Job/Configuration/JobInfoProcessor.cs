// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System;
using WebConsole.Core.Entities.Configuration;

namespace WebConsole.Core.Job.Configuration
{
    public interface IJobInfoProcessor
    {
        JobInfo Process(Type type);
    }

    public class JobInfoProcessor : IJobInfoProcessor
    {
        public JobInfo Process(Type type)
        {
            return new JobInfo
            {
                Name = type.Name,
                Namespace = type.Namespace,
                Location  = type.Assembly.Location
            };
        }
    }
}