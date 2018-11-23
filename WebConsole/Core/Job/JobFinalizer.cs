// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

namespace WebConsole.Core.Job
{
    public interface IJobFinalizer
    {
        bool Final(string id);
        void FinalAll();
    }

    public class JobFinalizer : IJobFinalizer
    {
        private readonly IJobBufferHandler buffer;

        public JobFinalizer(IJobBufferHandler buffer)
        {
            this.buffer = buffer;
        }

        public bool Final(string id)
        {
            var processes = buffer.LoadAll();
            var containsId = processes.ContainsKey(id);
            if (containsId)
            {
                buffer.Load(id).Dispose();
                processes.Remove(id);
            }
            return containsId;
        }

        public void FinalAll()
        {
            var processes = buffer.LoadAll();
            foreach (var process in processes)
                process.Value.Dispose();
            processes.Clear();
        }
    }
}