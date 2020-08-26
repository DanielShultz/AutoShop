using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoShop.Domain.Entities;

namespace AutoShop.Models
{
    public class DetailListViewModel
    {
        public IEnumerable<DetailItem> DetailItems { get; set; }
        public SelectList TypeItems { get; set; }
        public SelectList BrandItems { get; set; }
        public SelectList CarItems { get; set; }
    }
}