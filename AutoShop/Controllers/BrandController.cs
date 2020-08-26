using System.Web.Mvc;
using AutoShop.Domain;

namespace AutoShop.Controllers.Admin
{
    public class BrandController : Controller
    {
        private readonly AppDbContext context = new AppDbContext();

        public ActionResult Index()
        {
            return View(context.BrandItems);
        }
    }
}