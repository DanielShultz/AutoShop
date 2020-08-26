using System;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoShop.Domain;
using AutoShop.Domain.Entities;
using AutoShop.Service;

namespace WebApplication.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class BrandItemsController : Controller
    {
        AppDbContext context = new AppDbContext();

        public ActionResult Index()
        {
            return View(context.BrandItems);
        }

        public ActionResult Edit(Guid id)
        {
            ViewBag.Path = id.ToString() + ".jpeg";

            BrandItem entity = new BrandItem();

            if (id != Guid.Empty)
            {
                entity = context.BrandItems.FirstOrDefault(x => x.Id == id);
            }
            return View(entity);
        }

        [HttpPost]
        public ActionResult Edit(BrandItem model, HttpPostedFileBase titleImageFile)
        {
            if (ModelState.IsValid)
            {
                model.DateAdded = DateTime.Today;

                if (model.Id == Guid.Empty)
                {
                    model.Id = Guid.NewGuid();
                    while (context.BrandItems.Any(x => x.Id == model.Id))
                    {
                        model.Id = Guid.NewGuid();
                    }
                    context.Entry(model).State = EntityState.Added;
                }
                else
                {
                    context.Entry(model).State = EntityState.Modified;
                }
                context.SaveChanges();

                if (titleImageFile != null)
                {
                    titleImageFile.SaveAs(Server.MapPath("~/images/brands/" + model.Id.ToString() + ".jpeg"));
                }

                return RedirectToAction(nameof(BrandItemsController.Index), nameof(BrandItemsController).CutController());
            }
            return View(model);
        }

        public ActionResult Delete(Guid id)
        {
            context.BrandItems.Remove(context.BrandItems.FirstOrDefault(x => x.Id == id));
            context.SaveChanges();
            return RedirectToAction(nameof(BrandItemsController.Index), nameof(BrandItemsController).CutController());
        }
    }
}
