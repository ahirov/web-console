// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using WebConsole.Core.Entities;
using WebConsole.Core.Exceptions;
using WebConsole.Core.Extensions;
using static WebConsole.Core.ApplicationConstants;

namespace WebConsole.Core.Job.IO
{
    public interface IJobConfigReader
    {
        List<JobInfo> ReadJobs();
    }

    public class JobConfigReader : IJobConfigReader
    {
        public List<JobInfo> ReadJobs()
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            var path = Path.Combine(dir, JobConfigFile);
            var file = File.ReadAllText(path);

            var root = XDocument.Parse(file).Root;
            return !root.HasValue()
                ? throw new JobConfigMissingDataException()
                : root.Element(JobsName)
                      .Elements()
                      .Select(GetJobInfo)
                      .ToList();
        }

        private static JobInfo GetJobInfo(XElement element)
        {
            var name     = element.Value;
            var location = element.Attribute(LocationName)?.Value;

            return !name.HasValue() || !location.HasValue()
                ? throw new JobConfigMissingDataException()
                : new JobInfo
                {
                    Name = name.Trim(),
                    Location = location.Trim()
                };
        }
    }
}