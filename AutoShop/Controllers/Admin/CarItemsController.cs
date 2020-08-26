using System;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoShop.Domain;
using AutoShop.Domain.Entities;
using AutoShop.Service;

namespace AutoShop.Controllers.Admin
{
    [Authorize(Roles = "admin")]
    public class CarItemsController : Controller
    {
        AppDbContext context = new AppDbContext();

        public ActionResult Index()
        {
            return View(context.CarItems);
        }

        public ActionResult Edit(Guid id)
        {
            ViewBag.Path = id.ToString() + ".jpeg";

            CarItem entity = new CarItem();

            if (id != Guid.Empty)
            {
                entity = context.CarItems.FirstOrDefault(x => x.Id == id);
            }
            return View(entity);
        }

        [HttpPost]
        public ActionResult Edit(CarItem model, HttpPostedFileBase titleImageFile)
        {
            if (ModelState.IsValid)
            {
                model.DateAdded = DateTime.Today;

                if (model.Id == Guid.Empty)
                {
                    model.Id = Guid.NewGuid();
                    while (context.CarItems.Any(x => x.Id == model.Id))
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
                    titleImageFile.SaveAs(Server.MapPath("~/images/cars/" + model.Id.ToString() + ".jpeg"));
                }

                return RedirectToAction(nameof(CarItemsController.Index), nameof(CarItemsController).CutController());
            }
            return View(model);
        }

        public ActionResult Delete(Guid id)
        {
            context.CarItems.Remove(context.CarItems.FirstOrDefault(x => x.Id == id));
            context.SaveChanges();
            return RedirectToAction(nameof(CarItemsController.Index), nameof(CarItemsController).CutController());
        }
    }
}