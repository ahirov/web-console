// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using WebConsole.Core.Entities.Configuration;

namespace WebConsole.Core.Job.Configuration
{
    public interface IConfigInfoReader
    {
        ConfigurationInfo Read();
    }

    public class ConfigInfoReader : IConfigInfoReader
    {
        public ConfigurationInfo Read()
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            var path = Path.Combine(dir, ApplicationConstants.WcConfigFile);
            using (var reader = XmlReader.Create(path))
            {
                var serializer = new XmlSerializer(typeof(ConfigurationInfo));
                return (ConfigurationInfo)serializer.Deserialize(reader);
            }
        }
    }
}