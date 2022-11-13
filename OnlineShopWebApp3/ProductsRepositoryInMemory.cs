using OnlineShopWebApp3.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp3
{
    public class ProductsRepositoryInMemory : IProductsRepository
    {
        private static List<Product> products = new List<Product>()
        {
            new Product("Product1", 100, "Description1", "/images/product1.png"),
            new Product("Product2", 200, "Description2", "/images/product2.png"),
            new Product("Product3", 300, "Description3", "/images/product3.png"),
            new Product("Product4", 400, "Description4", "/images/product4.png"),
            new Product("Product5", 500, "Description5", "/images/product5.png")
        };

        public List<Product> GetAll()
        {
            return products;
        }

        public Product TryGetById(Guid productId)
        {
            var product = products.FirstOrDefault(x => x.Id == productId);
            return product;
        }

        public void Add(Product newProduct)
        {
            newProduct.ImagePath = "/images/placeholder.png";
            products.Add(newProduct);
        }

        public void Delete(Guid productId)
        {
            var product = products.FirstOrDefault(x => x.Id == productId);
            products.Remove(product);
        }

        public void Update(Product productToReplaceWith)
        {
            var productToUpdate = products.FirstOrDefault(x => x.Id == productToReplaceWith.Id);

            if (productToUpdate==null)
            {
                return;
            }

            productToUpdate.Name = productToReplaceWith.Name;
            productToUpdate.Cost = productToReplaceWith.Cost;
            productToUpdate.Description = productToReplaceWith.Description;
            productToUpdate.ImagePath = productToReplaceWith.ImagePath;


        }
    }
}
