using OnlineShopWebApp3.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp3
{
    public interface IProductsRepository
    {
        List<Product> GetAll();
        Product TryGetById(Guid productId);
    }
}