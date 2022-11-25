using OnlineShopWebApp3.Areas.User.Model;
using System;

namespace OnlineShopWebApp3.Model
{
    public interface ICartsRepository
    {
        void AddOrder(Order order, string userId);
        void AddProduct(Product product, string userId);
        Cart TryGetByUserId(string userId);
        void RemoveItem(Guid itemId);
        void Clear(string UserId);
    }
}