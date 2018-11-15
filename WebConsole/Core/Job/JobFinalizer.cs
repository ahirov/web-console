// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

namespace WebConsole.Core.Job
{
    public interface IJobFinalizer
    {
        void Final();
    }

    public class JobFinalizer : IJobFinalizer
    {
        private readonly IJobBufferHandler handler;

        public JobFinalizer(IJobBufferHandler handler)
        {
            this.handler = handler;
        }

        public void Final()
        {
            handler.LoadAll().ForEach(process => process.Dispose());
        }
    }
}