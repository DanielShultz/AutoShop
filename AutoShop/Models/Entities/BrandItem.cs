using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoShop.Domain.Entities
{
    public class BrandItem : EntityBase
    {
        [Required(ErrorMessage = "Заполните название бренда")]
        [Display(Name = "Название бренда")]
        public override string Title { get; set; }

        [Display(Name = "Краткое описание бренда")]
        public override string Subtitle { get; set; }

        [Display(Name = "Полное описпание бренда")]
        public override string Text { get; set; }
        public virtual ICollection<DetailItem> DetailItems { get; set; }
    }
}
