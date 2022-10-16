using OnlineShopWebApp3.Models;
using System;

namespace OnlineShopWebApp3
{
    public interface ICartsRepository
    {
        void Add(Product product, string userId);
        Cart TryGetByUserId(string userId);
    }
}