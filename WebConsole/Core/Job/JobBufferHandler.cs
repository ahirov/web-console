// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System;
using System.Collections.Generic;
using System.Diagnostics;
using WebConsole.Core.Job.Exceptions;
using static WebConsole.Core.ApplicationConstants;

namespace WebConsole.Core.Job
{
    public interface IJobBufferHandler
    {
        void Run(int id, Action<Process, Dictionary<int, Process>> action);
        void Run(Action<Dictionary<int, Process>> action);
        void RunAll(Action<Process> action);
        void Clear();
    }

    public class JobBufferHandler : IJobBufferHandler
    {
        private readonly IApplicationStorage<Dictionary<int, Process>> buffer;

        public JobBufferHandler(IApplicationStorage<Dictionary<int, Process>> buffer)
        {
            this.buffer = buffer;
        }

        public void Run(int id, Action<Process, Dictionary<int, Process>> action)
        {
            buffer.Invoke(JobSetKey, all =>
            {
                if (all.ContainsKey(id))
                    action.Invoke(all[id], all);
                else
                    throw new JobNotFoundException(id);
            });
        }

        public void Run(Action<Dictionary<int, Process>> action)
        {
            buffer.Invoke(JobSetKey, action.Invoke);
        }

        public void RunAll(Action<Process> action)
        {
            buffer.Invoke(JobSetKey, all =>
            {
                foreach (var item in all)
                {
                    action.Invoke(item.Value);
                }
            });
        }

        public void Clear()
        {
            buffer.Invoke(JobSetKey, all => all.Clear());
        }
    }
}