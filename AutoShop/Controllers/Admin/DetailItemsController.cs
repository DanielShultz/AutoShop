using System;
using System.Collections.Generic;
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
    public class DetailItemsController : Controller
    {
        AppDbContext context = new AppDbContext();

        public ActionResult Index()
        {
            return View(context.DetailItems.Include(b => b.BrandItems).Include(t => t.TypeItems));
        }

        public ActionResult Edit(Guid id)
        {
            ViewBag.Path = id.ToString() + ".jpeg";

            IEnumerable<BrandItem> brandItems = context.BrandItems.ToList();
            ViewBag.BrandItems = new SelectList(brandItems, "Id", "Title");

            IEnumerable<TypeItem> typeItems = context.TypeItems.ToList();
            ViewBag.TypeItems = new SelectList(typeItems, "Id", "Title");

            ViewBag.CarItems = context.CarItems.ToList();

            DetailItem entity = new DetailItem();

            if (id != Guid.Empty)
            {
                entity = context.DetailItems.FirstOrDefault(x => x.Id == id);
            }
            return View(entity);
        }

        [HttpPost]
        public ActionResult Edit(DetailItem model, HttpPostedFileBase titleImageFile, Guid[] selectedCars)
        {
            if (ModelState.IsValid)
            {
                DetailItem detailItem = context.DetailItems.Find(model.Id);

                detailItem.DateAdded = DateTime.Today;
                detailItem.BrandItemsId = model.BrandItemsId;
                detailItem.TypeItemsId = model.TypeItemsId;
                detailItem.Title = model.Title;
                detailItem.Subtitle = model.Subtitle;
                detailItem.Text = model.Text;
                detailItem.VendorCode = model.VendorCode;
                detailItem.Price = model.Price;
                detailItem.MetaDescription = model.MetaDescription;
                detailItem.MetaKeywords = model.MetaKeywords;
                detailItem.MetaTitle = model.MetaTitle;

                detailItem.CarItems.Clear();
                if (selectedCars != null)
                {
                    CarItem car = new CarItem();
                    foreach (Guid id in selectedCars)
                    {
                        car = context.CarItems.FirstOrDefault(x => x.Id == id);
                        detailItem.CarItems.Add(car);
                    }
                }

                if (detailItem.Id == Guid.Empty)
                {
                    detailItem.Id = Guid.NewGuid();
                    while (context.DetailItems.Any(x => x.Id == detailItem.Id))
                    {
                        detailItem.Id = Guid.NewGuid();
                    }
                    context.Entry(detailItem).State = EntityState.Added;
                }
                else
                {
                    context.Entry(detailItem).State = EntityState.Modified;
                }
                context.SaveChanges();

                if (titleImageFile != null)
                {
                    titleImageFile.SaveAs(Server.MapPath("~/images/details/" + detailItem.Id.ToString() + ".jpeg"));
                }

                return RedirectToAction(nameof(DetailItemsController.Index), nameof(DetailItemsController).CutController());
            }
            return View(model);
        }

        public ActionResult Delete(Guid id)
        {
            context.DetailItems.Remove(context.DetailItems.FirstOrDefault(x => x.Id == id));
            context.SaveChanges();
            return RedirectToAction(nameof(DetailItemsController.Index), nameof(DetailItemsController).CutController());
        }
    }
}