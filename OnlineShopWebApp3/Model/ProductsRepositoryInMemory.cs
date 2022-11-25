using OnlineShopWebApp3.Areas.User.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp3.Model
{
    public class ProductsRepositoryInMemory : IProductsRepository
    {
        private static List<Product> Products = new List<Product>()
        {
            new Product("Product1", 100, "Description1", "/images/product1.png"),
            new Product("Product2", 200, "Description2", "/images/product2.png"),
            new Product("Product3", 300, "Description3", "/images/product3.png"),
            new Product("Product4", 400, "Description4", "/images/product4.png"),
            new Product("Product5", 500, "Description5", "/images/product5.png")
        };

        public List<Product> GetAll()
        {
            return Products;
        }

        public Product TryGetById(Guid productId)
        {
            var product = Products.FirstOrDefault(x => x.Id == productId);
            return product;
        }

        public void Add(Product newProduct)
        {
            newProduct.ImagePath = "/images/placeholder.png";
            Products.Add(newProduct);
        }

        public void Delete(Guid productId)
        {
            var product = Products.FirstOrDefault(x => x.Id == productId);
            Products.Remove(product);
        }

        public void Update(Product productToReplaceWith)
        {
            var productToUpdate = Products.FirstOrDefault(x => x.Id == productToReplaceWith.Id);

            if (productToUpdate == null)
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
