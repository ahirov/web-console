// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System;
using WebConsole.Core.Entities;

namespace WebConsole.Core.Job.Info
{
    public interface IJobInfoProvider
    {
        JobInfo Get(Type type);
    }

    public class JobInfoProvider : IJobInfoProvider
    {
        public JobInfo Get(Type type)
        {
            return new JobInfo
            {
                Name = type.Name,
                FullName = type.FullName,
                Location = type.Assembly.Location
            };
        }
    }
}