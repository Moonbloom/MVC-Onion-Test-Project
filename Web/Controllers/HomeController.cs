using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult OmdbAPI()
        {
            ViewBag.Message = "Search for shows and movies - Using Omdb";

            return View();
        }

        public ActionResult TraktAPI()
        {
            ViewBag.Message = "Search for shows and movies - Using TraktTV";

            return View();
        }
    }
}