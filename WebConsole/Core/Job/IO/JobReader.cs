// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System.Diagnostics;
using System.Threading.Tasks;

namespace WebConsole.Core.Job.IO
{
    public interface IJobReader
    {
        Task<string> Read(Process job);
    }

    public class JobReader : IJobReader
    {
        public Task<string> Read(Process job)
        {
            return job.StandardOutput.ReadLineAsync();
        }
    }
}