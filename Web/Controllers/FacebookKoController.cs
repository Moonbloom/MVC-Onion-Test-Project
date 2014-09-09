using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class FacebookKoController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "FacebookKo";

            return View();
        }
    }
}