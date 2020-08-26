using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoShop.Service
{
    public class Config
    {
        public const string CompanyName = "Купи-Продай";
        public const string Detail = "Запчасть";
        public const string Details = "Запчасти";
        public const string Brand = "Бренд";
        public const string Brands = "Бренды";
        public const string Type = "Тип";
        public const string Types = "Типы";
        public const string Car = "Автомобиль";
        public const string Cars = "Автомобили";
        public const string Index = "Главная";
        public const string VendorCode = "Артикул";
        public static string ConnectionString { get; set; }
        public static string CompanyPhone { get; set; }
        public static string CompanyPhoneShort { get; set; }
        public static string CompanyEmail { get; set; }
    }
}
