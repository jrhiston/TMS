using Microsoft.AspNet.Mvc;

namespace TMS.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult TMS()
        {
            return PartialView();
        }
    }
}
