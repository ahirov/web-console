// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System.Web.Mvc;
using AttachedConsole;
using WebConsole.Core.Job;

namespace WebConsole.Controllers
{
    public class JobController : Controller
    {
        private readonly IJobInitializer initializer;
        private readonly IJobFinalizer finalizer;

        public JobController(IJobInitializer initializer,
                             IJobFinalizer finalizer)
        {
            this.initializer = initializer;
            this.finalizer = finalizer;
        }

        //
        // POST: /Job/Start
        [HttpPost]
        public ActionResult Start()
        {
            initializer.Init(typeof(Program));
            return Json(new {data = true});
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
        public ActionResult Read()
        {
            return View();
        }
    }
}