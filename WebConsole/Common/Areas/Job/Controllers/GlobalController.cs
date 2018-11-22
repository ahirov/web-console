// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AttachedConsole;
using Newtonsoft.Json;
using WebConsole.Controllers;
using WebConsole.Core.Job.Info;

namespace WebConsole.Areas.Job.Controllers
{
    public class GlobalController : BaseController
    {
        private readonly IJobInfoSetProvider jobInfoSetProvider;

        public GlobalController(IJobInfoSetProvider jobInfoSetProvider)
        {
            this.jobInfoSetProvider = jobInfoSetProvider;
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
            var set = jobInfoSetProvider.GetAll(jobs);
            return ReturnData(JsonConvert.SerializeObject(set));
        }
    }
}