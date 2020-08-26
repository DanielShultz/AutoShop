using System.Web.Mvc;

namespace WebApplication.Areas.Admin.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
