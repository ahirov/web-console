// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System.Diagnostics;

namespace WebConsole.Core.Job
{
    public interface IJobInitializer
    {
        bool Init(string id, string location);
    }

    public class JobInitializer : IJobInitializer
    {
        private readonly IJobBufferHandler buffer;

        public JobInitializer(IJobBufferHandler buffer)
        {
            this.buffer = buffer;
        }

        public bool Init(string id, string location)
        {
            var notContainsId = !buffer.LoadAll().ContainsKey(id);
            if (notContainsId)
                buffer.Save(id, Process.Start(GetInfo(location)));
            return notContainsId;
        }

        private static ProcessStartInfo GetInfo(string location)
        {
            return new ProcessStartInfo
            {
                FileName = location,
                RedirectStandardInput  = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow  = true
            };
        }
    }
}