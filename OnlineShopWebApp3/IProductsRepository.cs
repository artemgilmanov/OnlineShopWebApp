using OnlineShopWebApp3.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp3
{
    public interface IProductsRepository
    {
        void Add(Product newProduct);
        void Delete(Guid productId);
        List<Product> GetAll();
        Product TryGetById(Guid productId);
        void Update(Product productToReplaceWith);
    }
}