using AutoShop.Domain.Entities;
using System.Collections.Generic;

namespace AutoShop.Models
{
    public class IndexViewModel
    {
        public IEnumerable<CarItem> CarItems { get; set; }
        public IEnumerable<BrandItem> BrandItems { get; set; }
        public IEnumerable<TypeItem> TypeItems { get; set; }
    }
}