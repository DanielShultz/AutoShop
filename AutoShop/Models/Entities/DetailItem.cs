using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoShop.Domain.Entities
{
    public class DetailItem : EntityBase
    {
        [Required(ErrorMessage = "Заполните название детали")]
        [Display(Name = "Название детали")]
        public override string Title { get; set; }

        [Display(Name = "Краткое описание детали")]
        public override string Subtitle { get; set; }

        [Display(Name = "Полное описпание детали")]
        public override string Text { get; set; }

        [Display(Name = "Артикул")]
        public int VendorCode { get; set; }

        [Display(Name = "Цена")]
        public int Price { get; set; }

        [Display(Name = "Брэнд")]
        public Guid BrandItemsId {get; set;}
        public virtual BrandItem BrandItems { get; set; }

        [Display(Name = "Тип")]
        public Guid TypeItemsId { get; set; }
        public virtual TypeItem TypeItems { get; set; }

        public virtual ICollection<CarItem> CarItems { get; set; }
        public DetailItem()
        {
            CarItems = new List<CarItem>();
        }
    }
}
