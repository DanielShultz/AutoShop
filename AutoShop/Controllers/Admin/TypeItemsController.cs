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
    public class TypeItemsController : Controller
    {
        AppDbContext context = new AppDbContext();

        public ActionResult Index()
        {
            return View(context.TypeItems);
        }

        public ActionResult Edit(Guid id)
        {
            ViewBag.Path = id.ToString() + ".jpeg";

            TypeItem entity = new TypeItem();

            if (id != Guid.Empty)
            {
                entity = context.TypeItems.FirstOrDefault(x => x.Id == id);
            }
            return View(entity);
        }

        [HttpPost]
        public ActionResult Edit(TypeItem model, HttpPostedFileBase titleImageFile)
        {
            if (ModelState.IsValid)
            {
                model.DateAdded = DateTime.Today;

                if (model.Id == Guid.Empty)
                {
                    model.Id = Guid.NewGuid();
                    while (context.TypeItems.Any(x => x.Id == model.Id))
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
                    titleImageFile.SaveAs(Server.MapPath("~/images/types/" + model.Id.ToString() + ".jpeg"));
                }

                return RedirectToAction(nameof(TypeItemsController.Index), nameof(TypeItemsController).CutController());
            }
            return View(model);
        }

        public ActionResult Delete(Guid id)
        {
            context.TypeItems.Remove(context.TypeItems.FirstOrDefault(x => x.Id == id));
            context.SaveChanges();
            return RedirectToAction(nameof(TypeItemsController.Index), nameof(TypeItemsController).CutController());
        }
    }
}