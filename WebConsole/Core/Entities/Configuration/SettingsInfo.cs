// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System;
using System.Xml.Serialization;

namespace WebConsole.Core.Entities.Configuration
{
    [Serializable]
    public class SettingsInfo
    {
        [XmlElement("jobsLimit")]
        public int JobsLimit { get; set; }
    }
}