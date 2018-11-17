// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AttachedConsole;
using WebConsole.Core.Job;

namespace WebConsole.Controllers
{
    public class JobController : Controller
    {
        private readonly IJobBufferHandler handler;
        private readonly IJobInitializer initializer;
        private readonly IJobFinalizer finalizer;
        private readonly IJobReader jobReader;
        private readonly IJobWriter jobWriter;

        public JobController(IJobBufferHandler handler,
                             IJobInitializer initializer,
                             IJobFinalizer finalizer,
                             IJobReader jobReader,
                             IJobWriter jobWriter)
        {
            this.handler = handler;
            this.initializer = initializer;
            this.finalizer = finalizer;
            this.jobReader = jobReader;
            this.jobWriter = jobWriter;
        }

        //
        // POST: /Job/Start
        [HttpPost]
        public ActionResult Start()
        {
            // TODO Temp limit to one job!!! 
            if (!handler.LoadAll().Any())
            {
                initializer.Init(typeof(Program));
                return Json(new {data = true});
            }
            return Json(new {data = false});
        }

        //
        // POST: /Job/Stop
        [HttpPost]
        public ActionResult Stop()
        {
            finalizer.Final();
            return Json(new {data = true});
        }

        //
        // POST: /Job/Read
        [HttpPost]
        public async Task<ActionResult> Read()
        {
            // TODO!!!
            var job = handler.LoadAll().First().Value;
            var output = await jobReader.Read(job);
            return Json(new {data = output});
        }

        //
        // POST: /Job/Write
        [HttpPost]
        public async Task<ActionResult> Write(string input)
        {
            // TODO!!!
            var job = handler.LoadAll().First().Value;
            await jobWriter.Write(job, input);
            return Json(new {data = true});
        }
    }
}