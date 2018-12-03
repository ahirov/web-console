// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System.Diagnostics;
using Microsoft.AspNet.SignalR;
using WebConsole.Core.Job;

namespace WebConsole.Areas.Job.Hubs
{
    public class StreamHub : Hub
    {
        private readonly IJobProvider provider;
        private readonly IJobBufferHandler buffer;

        public StreamHub(IJobProvider provider,
                         IJobBufferHandler buffer)
        {
            this.provider = provider;
            this.buffer = buffer;
        }

        public int StartJob(string location, string args)
        {
            Process job = provider.GetJob(location, args,
                                          Clients.Caller);
            job.Start();
            job.BeginOutputReadLine();
            job.BeginErrorReadLine();

            buffer.Add(job);
            return job.Id;
        }

        public void StopJob(int id)
        {
            buffer.Run(id, (job, all) =>
            {
                if(!job.HasExited)
                    job.Kill();
                job.Dispose();
                all.Remove(id);
            });
        }

        public void Write(int id, string input)
        {
            buffer.Run(id, (job, all) =>
                          { job.StandardInput.WriteLine(input); });
        }
    }
}