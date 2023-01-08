using OnlineShop.Db.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db

{
    public class ProductsDbRepository : IProductsRepository
    {

        private readonly DataBaseContext _dataBaseContext;
        public ProductsDbRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public List<Product> GetAll()
        {
            return _dataBaseContext.Products.ToList();
        }

        public Product TryGetById(Guid productId)
        {
            return _dataBaseContext.Products.FirstOrDefault(x => x.Id == productId);
        }

        public void Add(Product newProduct)
        {
            var imageCounter = _dataBaseContext.Products.Count();
            newProduct.ImagePath = $"/images/product{imageCounter + 1}.png";
            
            _dataBaseContext.Products.Add(newProduct);
            _dataBaseContext.SaveChanges();
        }

        public void Delete(Guid productId)
        {
            var product = _dataBaseContext.Products.FirstOrDefault(x => x.Id == productId);
            _dataBaseContext.Products.Remove(product);
            _dataBaseContext.SaveChanges();
        }

        public void Update(Product productToReplaceWith)
        {
            var productToUpdate = _dataBaseContext.Products.FirstOrDefault(x => x.Id == productToReplaceWith.Id);

            if (productToUpdate == null)
            {
                return;
            }

            productToUpdate.Name = productToReplaceWith.Name;
            productToUpdate.Cost = productToReplaceWith.Cost;
            productToUpdate.Material = productToReplaceWith.Material;
            productToUpdate.Size = productToReplaceWith.Size;
            productToUpdate.Category = productToReplaceWith.Category;
            _dataBaseContext.SaveChanges();
        }

        public List<Product> TryGetByCategory(string category)
        {
            var products = GetAll().ToList();
            var productsByCategory = new List<Product>();

            foreach (var product in products)
            {
                if (product.Category== category)
                {
                    productsByCategory.Add(product);
                }
            }
            return productsByCategory;
        }
    }
}
