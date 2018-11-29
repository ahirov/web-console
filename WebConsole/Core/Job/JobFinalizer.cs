// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

namespace WebConsole.Core.Job
{
    public interface IJobFinalizer
    {
        void FinalAll();
    }

    public class JobFinalizer : IJobFinalizer
    {
        private readonly IJobBufferHandler buffer;

        public JobFinalizer(IJobBufferHandler buffer)
        {
            this.buffer = buffer;
        }

        public void FinalAll()
        {
            buffer.RunAll(job => job.Dispose());
            buffer.Clear();
        }
    }
}