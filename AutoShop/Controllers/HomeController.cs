using AutoShop.Domain;
using AutoShop.Domain.Entities;
using AutoShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext context = new AppDbContext();
        public ActionResult Index() 
        {
            IndexViewModel indexView = new IndexViewModel
            {
                BrandItems = context.BrandItems.Take(4).ToList(),
                CarItems = context.CarItems.Take(4).ToList(),
                TypeItems = context.TypeItems.Take(3).ToList()
            };
            return View(indexView);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}