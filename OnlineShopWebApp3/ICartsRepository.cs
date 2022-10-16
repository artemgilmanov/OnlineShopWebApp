using OnlineShopWebApp3.Models;
using System;

namespace OnlineShopWebApp3
{
    public interface ICartsRepository
    {
        void AddToCart(Product product, string userId);

        Cart TryGetByUserId(string userId);

        void RemoveFromCart(Guid itemId);
    }
}