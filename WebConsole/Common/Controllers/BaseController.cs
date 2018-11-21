// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System.Web.Mvc;

namespace WebConsole.Controllers
{
    public class BaseController : Controller
    {
        public ActionResult Success()
        {
            return Json(new {data = true});
        }

        public ActionResult Failure()
        {
            return Json(new {data = false});
        }

        public ActionResult ReturnData(string data)
        {
            return Json(new {data});
        }
    }
}