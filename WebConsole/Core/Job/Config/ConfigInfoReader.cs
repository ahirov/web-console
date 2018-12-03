// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using WebConsole.Core.Entities;
using WebConsole.Core.Extensions;
using WebConsole.Core.Job.Exceptions;
using static WebConsole.Core.ApplicationConstants;

namespace WebConsole.Core.Job.Config
{
    public interface IConfigInfoReader
    {
        ConfigInfo Read();
    }

    public class ConfigInfoReader : IConfigInfoReader
    {
        private readonly IJobInfoReader jobInfoReader;

        public ConfigInfoReader(IJobInfoReader jobInfoReader)
        {
            this.jobInfoReader = jobInfoReader;
        }

        public ConfigInfo Read()
        {
            var root = GetRoot();
            if (!root.HasValue())
                throw new JobConfigFileException();
            return new ConfigInfo
            {
                JobsLimit = root.Element(SettingsLiteral)
                                .Element(JobsLimitLiteral)
                                .Value,
                Jobs = root.Element(JobsLiteral)
                           .Elements()
                           .Select(jobInfoReader.Read)
                           .ToList()
            };
        }

        private static XElement GetRoot()
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            var path = Path.Combine(dir, WcConfigFile);
            var file = File.ReadAllText(path);

            return XDocument.Parse(file).Root;
        }
    }
}