using System;

namespace OnlineShopWebApp3.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public Product()
        {

        }

        public Product(string name, decimal cost, string description, string imagePath)
        {
            Id = Guid.NewGuid();
            Name = name;
            Cost = cost;
            Description = description;
            ImagePath = imagePath;
        }
       
    }
}
