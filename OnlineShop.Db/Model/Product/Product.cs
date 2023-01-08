using System;
using System.Collections.Generic;

namespace OnlineShop.Db.Model
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Material { get; set; }
        public string Size { get; set; }
        public string ImagePath { get; set; }
        public string Category { get; set; }
        public List<CartItem> CartItems { get; set; }
        public Product()
        {
            Id = Guid.NewGuid();
            CartItems = new List<CartItem>();
        }
    }
}
