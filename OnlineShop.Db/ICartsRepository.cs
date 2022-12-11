using OnlineShop.Db.Model;
using System;

namespace OnlineShop.Db
{
    public interface ICartsRepository
    {
        void AddOrder(Order order, string userId);
        void AddProduct(ProductViewModel product, string userId);
        Cart TryGetByUserId(string userId);
        void Clear(string UserId);
        void RemoveItem(Guid itemId, string userId);
    }
}