using OnlineShop.Db.Model;
using System;
using System.Collections.Generic;

namespace OnlineShop.Db
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