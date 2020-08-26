using AutoShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoShop.Domain;
using AutoShop.Domain.Entities;

namespace AutoShop.Controllers
{
    public class DetailController : Controller
    {
        private readonly AppDbContext context = new AppDbContext();

        public ActionResult Index(Guid? type, Guid? brand, Guid? car, int? vendorCode)
        {
            IQueryable<DetailItem> detailItems = context.DetailItems;

            if (vendorCode != null)
            {
                detailItems = detailItems.Where(v => v.VendorCode == vendorCode);
            }
            if (type != null && type != Guid.Empty)
            {
                detailItems = detailItems.Where(t => t.TypeItemsId == type);
            }
            if (brand != null && brand != Guid.Empty)
            {
                detailItems = detailItems.Where(b => b.BrandItemsId == brand);
            }
            if (car != null && car != Guid.Empty)
            {
                detailItems = detailItems.Where(c => c.CarItems.Contains(context.CarItems.FirstOrDefault(x => x.Id == car)));
            }

            List<TypeItem> typeItems = context.TypeItems.ToList();
            typeItems.Insert(0, new TypeItem { Title = "Все", Id = Guid.Empty });
            List<BrandItem> brandItems = context.BrandItems.ToList();
            brandItems.Insert(0, new BrandItem { Title = "Все", Id = Guid.Empty });
            List<CarItem> carItems = context.CarItems.ToList();
            carItems.Insert(0, new CarItem { Title = "Все", Id = Guid.Empty });

            DetailListViewModel detailList = new DetailListViewModel
            {
                DetailItems = detailItems.ToList(),
                TypeItems = new SelectList(typeItems,"Id","Title"),
                BrandItems = new SelectList(brandItems,"Id","Title"),
                CarItems = new SelectList(carItems,"Id","Title")
            };

            return View(detailList);
        }

        public ActionResult Show(Guid id)
        {
            return View(context.DetailItems.FirstOrDefault(x => x.Id == id));
        }
    }
}
