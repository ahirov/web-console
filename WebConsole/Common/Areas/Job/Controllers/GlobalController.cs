// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AttachedConsole;
using Newtonsoft.Json;
using WebConsole.Controllers;
using WebConsole.Core.Job;
using WebConsole.Core.Job.Info;

namespace WebConsole.Areas.Job.Controllers
{
    public class GlobalController : BaseController
    {
        private readonly IJobInfoSetProvider provider;
        private readonly IJobFinalizer finalizer;
        
        public GlobalController(IJobInfoSetProvider provider,
                                IJobFinalizer finalizer)
        {
            this.provider = provider;
            this.finalizer = finalizer;
        }

        //
        // POST: /Job/Global/GetAll
        [HttpPost]
        public ActionResult GetAll()
        {
            // Attach your console application here
            // or
            // use jobs.xml configuration file!!!
            var jobs = new List<Type> {typeof(Program)};
            var infos = provider.GetAll(jobs);
            return ReturnData(JsonConvert.SerializeObject(infos));
        }

        //
        // POST: /Job/Global/StopAll
        [HttpPost]
        public ActionResult StopAll()
        {
            finalizer.FinalAll();
            return Success();
        }
    }
}