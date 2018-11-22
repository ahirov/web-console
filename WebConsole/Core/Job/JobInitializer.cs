// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System.Diagnostics;

namespace WebConsole.Core.Job
{
    public interface IJobInitializer
    {
        void Init(string location);
    }

    public class JobInitializer : IJobInitializer
    {
        private readonly IJobBufferHandler handler;

        public JobInitializer(IJobBufferHandler handler)
        {
            this.handler = handler;
        }

        public void Init(string location)
        {
            handler.Save(Process.Start(GetInfo(location)));
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