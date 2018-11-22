// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System.Collections.Generic;
using System.Diagnostics;
using static WebConsole.Core.ApplicationConstants;

namespace WebConsole.Core.Job
{
    public interface IJobBufferHandler
    {
        void Init();
        void Save(string id, Process job);
        Process Load(string id);
        Dictionary<string, Process> LoadAll();
    }

    public class JobBufferHandler : IJobBufferHandler
    {
        private readonly IApplicationStorage<Dictionary<string, Process>> buffer;

        public JobBufferHandler(IApplicationStorage<Dictionary<string, Process>> buffer)
        {
            this.buffer = buffer;
        }

        public void Init()
        {
            buffer[JobSetKey] = new Dictionary<string, Process>();
        }

        public void Save(string id, Process job)
        {
            buffer.Action(JobSetKey, set => set[id] = job);
        }

        public Process Load(string id)
        {
            // TODO Add job checking!!!
            return buffer[JobSetKey][id];
        }

        public Dictionary<string, Process> LoadAll()
        {
            return buffer[JobSetKey];
        }
    }
}