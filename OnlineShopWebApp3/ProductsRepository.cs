using OnlineShopWebApp3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace OnlineShopWebApp3
{
    public static class ProductsRepository
    {
        private static List<Product> products = new List<Product>()
        {
            new Product(Guid.NewGuid(), "Product1", 100, "Description1", "/images/product1.png"),
            new Product(Guid.NewGuid(), "Product2", 200, "Description2", "/images/product2.png"),
            new Product(Guid.NewGuid(), "Product3", 300, "Description3", "/images/product3.png"),
            new Product(Guid.NewGuid(), "Product4", 400, "Description4", "/images/product4.png"),
            new Product(Guid.NewGuid(), "Product5", 500, "Description5", "/images/product5.png")
        };
        public static List<Product> GetAll()
        {
            return products;
        }

        public static Product TryGetById(Guid productId)
        {
            var product = products.FirstOrDefault(x => x.Id == productId);
            return product;
        }
    }
}
