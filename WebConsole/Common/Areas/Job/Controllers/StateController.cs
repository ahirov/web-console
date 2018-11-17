// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System.Linq;
using System.Web.Mvc;
using AttachedConsole;
using WebConsole.Core.Job;

namespace WebConsole.Areas.Job.Controllers
{
    public class StateController : Controller
    {
        private readonly IJobBufferHandler buffer;
        private readonly IJobInitializer initializer;
        private readonly IJobFinalizer finalizer;

        public StateController(IJobBufferHandler buffer,
                               IJobInitializer initializer,
                               IJobFinalizer finalizer)
        {
            this.buffer = buffer;
            this.initializer = initializer;
            this.finalizer = finalizer;
        }

        //
        // POST: /Job/State/Start
        [HttpPost]
        public ActionResult Start()
        {
            // TODO Temp limit to one job!!! 
            if (!buffer.LoadAll().Any())
            {
                initializer.Init(typeof(Program));
                return Json(new { data = true });
            }
            return Json(new {data = false});
        }

        //
        // POST: /Job/State/Stop
        [HttpPost]
        public ActionResult Stop()
        {
            finalizer.Final();
            return Json(new {data = true});
        }
    }
}