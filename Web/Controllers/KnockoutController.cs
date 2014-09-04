using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class KnockoutController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Knockout";

            return View();
        }
    }
}