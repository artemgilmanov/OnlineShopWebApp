using OnlineShopWebApp3.Models;
using System;

namespace OnlineShopWebApp3
{
    public interface ICartsRepository
    {
        void AddOrder(Order order, string userId);
        void AddProduct(Product product, string userId);
        Cart TryGetByUserId(string userId);
        void RemoveFromCart(Guid itemId);
        void Clear(string UserId);
    }
}