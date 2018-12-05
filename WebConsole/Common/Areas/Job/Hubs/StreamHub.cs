// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using Microsoft.AspNet.SignalR;
using WebConsole.Core.Job;
using WebConsole.Core.Job.Initialization;

namespace WebConsole.Areas.Job.Hubs
{
    public class StreamHub : Hub
    {
        private readonly IJobProvider jobProvider;
        private readonly IJobProcessor jobProcessor;
        private readonly IJobBufferHandler buffer;

        public StreamHub(IJobProvider jobProvider,
                         IJobProcessor jobProcessor,
                         IJobBufferHandler buffer)
        {
            this.jobProvider = jobProvider;
            this.jobProcessor = jobProcessor;
            this.buffer = buffer;
        }

        public int StartJob(string location, string args)
        {
            var id = 0;
            buffer.Run(all =>
            {
                if (all.Count < jobProcessor.GetLimit())
                {
                    var job = jobProvider.GetJob(location, args,
                                                 Clients.Caller);
                    id = jobProcessor.Process(job, all);
                }
            });
            return id;
        }

        public void StopJob(int id)
        {
            buffer.Run(id, (item, all) =>
            {
                var process = item.Process;
                if(!process.HasExited)
                    process.Kill();
                process.Dispose();
                all.Remove(id);
            });
        }

        public void Write(int id, string input)
        {
            buffer.Run(id, (item, all) =>
                          { item.Process.StandardInput.WriteLine(input); });
        }
    }
}