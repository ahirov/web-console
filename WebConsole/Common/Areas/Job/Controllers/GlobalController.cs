// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Newtonsoft.Json;
using WebConsole.Controllers;
using WebConsole.Core.Job;
using WebConsole.Core.Job.Config;
using Console = AttachedConsole;
using ConsoleWithError = AttachedConsoleWithError;
using static WebConsole.Core.ApplicationConstants;

namespace WebConsole.Areas.Job.Controllers
{
    public class GlobalController : BaseController
    {
        private readonly IConfigInfoProcessor configProcessor;
        private readonly IJobDescriptionsProvider jobProvider;
        private readonly IJobFinalizer jobFinalizer;

        public GlobalController(IConfigInfoProcessor configProcessor,
                                IJobDescriptionsProvider jobProvider,
                                IJobFinalizer jobFinalizer)
        {
            this.configProcessor = configProcessor;
            this.jobProvider = jobProvider;
            this.jobFinalizer = jobFinalizer;
        }

        //
        // POST: /Job/Global/GetInfos
        [HttpPost]
        public ActionResult GetInfos()
        {
            var jobs = new List<Type>
            {
                typeof(Console.Program),
                typeof(ConsoleWithError.Program)
            };
            var config = configProcessor.Process(jobs);
            ConfigurationManager.AppSettings[JobsLimitLiteral] = config.JobsLimit;
            return ReturnData(JsonConvert.SerializeObject(config.Jobs));
        }

        //
        // POST: /Job/Global/GetStatistics
        [HttpPost]
        public ActionResult GetStatistics()
        {
            var descriptions = jobProvider.GetDescriptions();
            return ReturnData(JsonConvert.SerializeObject(descriptions));
        }

        //
        // POST: /Job/Global/StopAllOwn
        [HttpPost]
        public ActionResult StopAllOwn(string data)
        {
            var ids = JsonConvert.DeserializeObject<List<int>>(data);
            jobFinalizer.FinalAll(ids);
            return Success();
        }
    }
}