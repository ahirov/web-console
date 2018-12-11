// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System;
using System.Collections.Generic;
using System.Linq;
using WebConsole.Core.Entities;

namespace WebConsole.Core.Job
{
    public interface IJobFinalizer
    {
        void FinalAll(double interval);
        void FinalAll(List<int> ids);
        void FinalAll();
    }

    public class JobFinalizer : IJobFinalizer
    {
        private readonly IJobBufferHandler buffer;

        public JobFinalizer(IJobBufferHandler buffer)
        {
            this.buffer = buffer;
        }

        public void FinalAll(double interval)
        {
            FinalAll(pair => (DateTime.Now - pair.Value.Process.StartTime)
                             .TotalMilliseconds >= interval);
        }

        public void FinalAll(List<int> ids)
        {
            FinalAll(pair => ids.Contains(pair.Key));
        }

        public void FinalAll()
        {
            buffer.RunAll(FinalJob);
            buffer.Clear();
        }

        private void FinalAll(Func<KeyValuePair<int, JobContent>, bool> predicate)
        {
            buffer.Run(all =>
            {
                var removable = all.Where(predicate).ToList();
                foreach (var pair in removable)
                {
                    FinalJob(pair.Value);
                    all.Remove(pair.Key);
                }
            });
        }

        private static void FinalJob(JobContent content)
        {
            var process = content.Process;
            if (!process.HasExited)
                process.Kill();
            process.Dispose();
        }
    }
}