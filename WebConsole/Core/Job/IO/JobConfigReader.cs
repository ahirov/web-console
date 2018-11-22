// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System.Xml.Linq;
using WebConsole.Core.Entities;
using WebConsole.Core.Exceptions;
using WebConsole.Core.Extensions;
using WebConsole.Core.Job.Info;
using static WebConsole.Core.ApplicationConstants;

namespace WebConsole.Core.Job.IO
{
    public interface IJobConfigReader
    {
        JobInfo Read(XElement element);
    }

    public class JobConfigReader : IJobConfigReader
    {
        private readonly IJobIdProvider idProvider;

        public JobConfigReader(IJobIdProvider idProvider)
        {
            this.idProvider = idProvider;
        }

        public JobInfo Read(XElement element)
        {
            var name = element.Value;
            var location = element.Attribute(LocationName)?.Value;
            var ns = element.Attribute(NamespaceName)?.Value;

            return !name.HasValue() || !location.HasValue()
                ? throw new JobConfigMissingDataException()
                : new JobInfo
                {
                    Id = idProvider.GetId(),
                    Name = name.Trim(),
                    FullName = $"{ns.Trim()}.{name.Trim()}",
                    Location = location.Trim()
                };
        }
    }
}