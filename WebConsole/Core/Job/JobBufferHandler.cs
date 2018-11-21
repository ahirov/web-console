﻿// WebConsole (https://github.com/hirov-anton/web-console)
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
        void Save(Process job);
        Process Load(int id);
        Dictionary<int, Process> LoadAll();
    }

    public class JobBufferHandler : IJobBufferHandler
    {
        private readonly IApplicationStorage<Dictionary<int, Process>> buffer;

        public JobBufferHandler(IApplicationStorage<Dictionary<int, Process>> buffer)
        {
            this.buffer = buffer;
        }

        public void Init()
        {
            buffer[JobSetKey] = new Dictionary<int, Process>();
        }

        public void Save(Process job)
        {
            buffer.Action(JobSetKey, set => set[job.Id] = job);
        }

        public Process Load(int id)
        {
            // TODO Add job checking!!!
            return buffer[JobSetKey][id];
        }

        public Dictionary<int, Process> LoadAll()
        {
            return buffer[JobSetKey];
        }
    }
}