// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System;
using System.Diagnostics;

namespace WebConsole.Core.Job
{
    public interface IJobInitializer
    {
        void Init(Type type);
    }

    public class JobInitializer : IJobInitializer
    {
        private readonly IJobBufferHandler handler;

        public JobInitializer(IJobBufferHandler handler)
        {
            this.handler = handler;
        }

        public void Init(Type type)
        {
            handler.Save(Process.Start(GetInfo(type)));
        }

        private static ProcessStartInfo GetInfo(Type type)
        {
            return new ProcessStartInfo
            {
                FileName = type.Assembly.Location,
                RedirectStandardInput  = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow  = true
            };
        }
    }
}