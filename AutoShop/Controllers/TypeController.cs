using System.Web.Mvc;
using AutoShop.Domain;

namespace AutoShop.Controllers
{
    public class TypeController : Controller
    {
        private readonly AppDbContext context = new AppDbContext();

        public ActionResult Index()
        {
            return View(context.TypeItems);
        }
    }
}