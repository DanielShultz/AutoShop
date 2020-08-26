using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoShop.Domain.Entities
{
    public class TypeItem : EntityBase
    {
        [Required(ErrorMessage = "Заполните название типа детали")]
        [Display(Name = "Название типа детали")]
        public override string Title { get; set; }

        [Display(Name = "Краткое описание типа детали")]
        public override string Subtitle { get; set; }

        [Display(Name = "Полное описпание типа детали")]
        public override string Text { get; set; }
        public virtual ICollection<DetailItem> DetailItems { get; set; }
    }
}
