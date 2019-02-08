// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace WebConsole.Core.Entities.Configuration
{
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class JobInfo
    {
        [XmlText]
        [JsonProperty("name",      Required = Required.Always)]
        public string Name { get; set; }

        [XmlAttribute("namespace")]
        [JsonProperty("namespace", Required = Required.Always)]
        public string @Namespace { get; set; }

        [XmlAttribute("location")]
        [JsonProperty("location",  Required = Required.Always)]
        public string Location { get; set; }
    }
}