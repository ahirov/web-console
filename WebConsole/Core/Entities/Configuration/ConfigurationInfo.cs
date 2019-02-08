// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace WebConsole.Core.Entities.Configuration
{
    [Serializable]
    [XmlRoot("configuration")]
    public class ConfigurationInfo
    {
        [XmlElement("settings")]
        public SettingsInfo Settings { get; set; }

        [XmlArray("jobs")]
        [XmlArrayItem("job")]
        public List<JobInfo> Jobs { get; set; }
    }
}