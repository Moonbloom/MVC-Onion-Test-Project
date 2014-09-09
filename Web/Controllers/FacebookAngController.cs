using System.Web.Mvc;

namespace Web.Controllers
{
    public class FacebookAngController : Controller
    {
        #region Index
        public ActionResult Index()
        {
            ViewBag.Message = "FacebookAng";

            return View();
        }
        #endregion
    }
}