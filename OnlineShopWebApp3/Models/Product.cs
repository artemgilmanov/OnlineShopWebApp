using System;

namespace OnlineShopWebApp3.Models
{
    public class Product
    {
        public Guid Id { get; }
        public string Name { get; }
        public decimal Cost { get; }
        public string Description { get; }
        public string ImagePath { get; }
        public Product(Guid id, string name, decimal cost, string description, string imagePath)
        {
            Id = Guid.NewGuid();
            Name = name;
            Cost = cost;
            Description = description;
            ImagePath = imagePath;
        }
    }
}
