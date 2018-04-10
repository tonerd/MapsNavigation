using System.Web.Mvc;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return Json(new { status = "Application running" }, JsonRequestBehavior.AllowGet);
        }
    }
}