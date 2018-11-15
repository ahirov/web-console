// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace WebConsole.Core.Job
{
    public interface IJobBufferHandler
    {
        void Save(Process job);
        Process Load(int id);
        List<Process> LoadAll();
    }

    public class JobBufferHandler : IJobBufferHandler
    {
        private readonly IApplicationStorage<Dictionary<int, Process>> buffer;

        public JobBufferHandler(IApplicationStorage<Dictionary<int, Process>> buffer)
        {
            this.buffer = buffer;
        }

        public void Save(Process job)
        {
            buffer.Action(StorageKeys.JobSet, set => set[job.Id] = job);
        }

        public Process Load(int id)
        {
            // TODO Add job checking!!!
            return buffer[StorageKeys.JobSet][id];
        }

        public List<Process> LoadAll()
        {
            return buffer[StorageKeys.JobSet].Values.ToList();
        }
    }
}