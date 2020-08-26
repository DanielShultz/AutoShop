using System.Web.Mvc;
using AutoShop.Domain;

namespace AutoShop.Controllers
{
    public class CarController : Controller
    {
        private readonly AppDbContext context = new AppDbContext();
        public ActionResult Index()
        {
            return View(context.CarItems);
        }
    }
}