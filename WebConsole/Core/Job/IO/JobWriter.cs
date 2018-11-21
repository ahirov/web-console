// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System.Diagnostics;
using System.Threading.Tasks;

namespace WebConsole.Core.Job.IO
{
    public interface IJobWriter
    {
        Task Write(Process job, string input);
    }

    public class JobWriter : IJobWriter
    {
        public Task Write(Process job, string input)
        {
            return job.StandardInput.WriteLineAsync(input);
        }
    }
}