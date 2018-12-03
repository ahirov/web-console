// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System.Configuration;
using System.Diagnostics;
using Microsoft.AspNet.SignalR;
using WebConsole.Core.Job;
using static WebConsole.Core.ApplicationConstants;

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
            var id = 0;
            buffer.Run(all =>
            {
                if (all.Count < GetLimit())
                {
                    Process job = provider.GetJob(location, args,
                                                  Clients.Caller);
                    job.Start();
                    job.BeginOutputReadLine();
                    job.BeginErrorReadLine();
                    id = job.Id;
                    all[id] = job;
                }
            });
            return id;
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

        private static int GetLimit()
        {
            var setting = ConfigurationManager.AppSettings[JobsLimitLiteral];
            var isSuccessful = int.TryParse(setting, out var limit);
            return isSuccessful ? limit : DefaultJobsLimit;
        }
    }
}