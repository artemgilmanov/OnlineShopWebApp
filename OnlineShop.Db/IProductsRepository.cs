using OnlineShop.Db.Model;
using System;
using System.Collections.Generic;

namespace OnlineShop.Db
{
    public interface IProductsRepository
    {
        void Add(ProductViewModel newProduct);
        void Delete(Guid productId);
        List<ProductViewModel> GetAll();
        ProductViewModel TryGetById(Guid productId);
        void Update(ProductViewModel productToReplaceWith);
    }
}