using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoShop.Domain.Entities
{
    public class CarItem : EntityBase
    {
        [Required(ErrorMessage = "Заполните название автомобиля")]
        [Display(Name = "Название автомобиля")]
        public override string Title { get; set; }

        [Display(Name = "Краткое описание автомобиля")]
        public override string Subtitle { get; set; }

        [Display(Name = "Полное описание автомобиля")]
        public override string Text { get; set; }

        public virtual ICollection<DetailItem> DetailItems { get; set; }
        public CarItem()
        {
            DetailItems = new List<DetailItem>();
        }
    }
}
