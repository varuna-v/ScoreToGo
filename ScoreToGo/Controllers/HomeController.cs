using System.Web.Mvc;

namespace ScoreToGo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StartRotation()
        {
            return RedirectToAction("Index", "Game");
        }
    }
}