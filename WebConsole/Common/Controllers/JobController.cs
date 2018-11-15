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

        public JobController(IJobInitializer initializer)
        {
            this.initializer = initializer;
        }

        //
        // POST: /Job/Start
        [HttpPost]
        public ActionResult Start()
        {
            initializer.Init(typeof(Program));
            return new EmptyResult();
        }

        //
        // POST: /Job/Stop
        [HttpPost]
        public ActionResult Stop()
        {
            return View();
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