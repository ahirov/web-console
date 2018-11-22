// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using Newtonsoft.Json;

namespace WebConsole.Core.Entities
{
    [JsonObject(MemberSerialization.OptIn)]
    public class JobInfo
    {
        [JsonProperty("id",       Required = Required.Always)]
        public string Id { get; set; }

        [JsonProperty("name",     Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("fullName", Required = Required.Always)]
        public string FullName { get; set; }

        [JsonProperty("location", Required = Required.Always)]
        public string Location { get; set; }
    }
}