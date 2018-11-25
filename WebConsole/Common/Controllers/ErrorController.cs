// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System;
using System.Web.Mvc;

namespace WebConsole.Controllers
{
    public class ErrorController : BaseController
    {
        // GET: /Error/Critical
        public ActionResult Critical()
        {
            var error = (Exception)Session["error"]
                  ?? new Exception("No error message...");
            return View(error);
        }

        // GET: /Error/PageNotFound
        public ActionResult PageNotFound()
        {
            return View();
        }
    }
}