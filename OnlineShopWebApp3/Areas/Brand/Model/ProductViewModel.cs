using System;

namespace OnlineShopWebApp3.Areas.Brand.Model
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Material { get; set; }
        public string Size { get; set; }
        public string Category { get; set; }
        public string ImagePath { get; set; }
    }
}
