// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System.Xml.Linq;
using WebConsole.Core.Entities;
using WebConsole.Core.Extensions;
using WebConsole.Core.Job.Exceptions;
using static WebConsole.Core.ApplicationConstants;

namespace WebConsole.Core.Job.Config
{
    public interface IJobConfigReader
    {
        JobInfo Read(XElement element);
    }

    public class JobConfigReader : IJobConfigReader
    {
        public JobInfo Read(XElement element)
        {
            var name = element.Value;
            var location = element.Attribute(LocationName)?.Value;
            var ns = element.Attribute(NamespaceName)?.Value;

            return !name.HasValue() || !location.HasValue()
                ? throw new JobConfigFileException()
                : new JobInfo
                {
                    Name = name.Trim(),
                    FullName = $"{ns.Trim()}.{name.Trim()}",
                    Location = location.Trim()
                };
        }
    }
}