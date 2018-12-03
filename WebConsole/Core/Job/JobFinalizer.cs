// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace WebConsole.Core.Job
{
    public interface IJobFinalizer
    {
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

        public void FinalAll(List<int> ids)
        {
            buffer.Run(all =>
            {
                var removable = all.Where(pair => ids.Contains(pair.Key))
                                   .ToList();
                foreach (var pair in removable)
                {
                    FinalJob(pair.Value);
                    all.Remove(pair.Key);
                }
            });
        }

        public void FinalAll()
        {
            buffer.RunAll(FinalJob);
            buffer.Clear();
        }

        private static void FinalJob(Process job)
        {
            if (!job.HasExited)
                job.Kill();
            job.Dispose();
        }
    }
}