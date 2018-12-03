// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System;
using WebConsole.Core.Entities;

namespace WebConsole.Core.Job.Config
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
                FullName = type.FullName,
                Location = type.Assembly.Location
            };
        }
    }
}