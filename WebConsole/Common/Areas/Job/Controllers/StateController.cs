// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System.Web.Mvc;
using WebConsole.Controllers;
using WebConsole.Core.Job;

namespace WebConsole.Areas.Job.Controllers
{
    public class StateController : BaseController
    {
        private readonly IJobInitializer initializer;
        private readonly IJobFinalizer finalizer;

        public StateController(IJobInitializer initializer,
                               IJobFinalizer finalizer)
        {
            this.initializer = initializer;
            this.finalizer = finalizer;
        }

        //
        // POST: /Job/State/Start
        [HttpPost]
        public ActionResult Start(string id,
                                  string location,
                                  string args)
        {
            return initializer.Init(id, location)
                ? Success()
                : Failure();
        }

        //
        // POST: /Job/State/Stop
        [HttpPost]
        public ActionResult Stop(string id)
        {
            return finalizer.Final(id)
                ? Success()
                : Failure();
        }

        //
        // POST: /Job/State/StopAll
        [HttpPost]
        public ActionResult StopAll()
        {
            finalizer.FinalAll();
            return Success();
        }
    }
}