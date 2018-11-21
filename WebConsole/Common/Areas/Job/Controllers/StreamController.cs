// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebConsole.Controllers;
using WebConsole.Core.Job;
using WebConsole.Core.Job.IO;

namespace WebConsole.Areas.Job.Controllers
{
    public class StreamController : BaseController
    {
        private readonly IJobBufferHandler buffer;
        private readonly IJobReader jobReader;
        private readonly IJobWriter jobWriter;

        public StreamController(IJobBufferHandler buffer,
                                IJobReader jobReader,
                                IJobWriter jobWriter)
        {
            this.buffer = buffer;
            this.jobReader = jobReader;
            this.jobWriter = jobWriter;
        }

        //
        // POST: /Job/Stream/Read
        [HttpPost]
        public async Task<ActionResult> Read()
        {
            // TODO!!!
            var job = buffer.LoadAll().First().Value;
            var output = await jobReader.Read(job);
            return Json(new {data = output});
        }

        //
        // POST: /Job/Stream/Write
        [HttpPost]
        public async Task<ActionResult> Write(string input)
        {
            // TODO!!!
            var job = buffer.LoadAll().First().Value;
            await jobWriter.Write(job, input);
            return Success();
        }
    }
}