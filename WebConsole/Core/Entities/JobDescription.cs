// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using Newtonsoft.Json;

namespace WebConsole.Core.Entities
{
    [JsonObject(MemberSerialization.OptIn)]
    public class JobDescription
    {
        [JsonProperty("name",      Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("startTime", Required = Required.Always)]
        public string StartTime { get; set; }
    }
}