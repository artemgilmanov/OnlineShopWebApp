using OnlineShop.Db.Model;
using System;
using System.Collections.Generic;

namespace OnlineShop.Db
{
    public interface IOrdersRepository
    {
        void Add(Order order);
        List<Order> GetAll();
        Order TryGetById(Guid orderId);
        void UpdateOrderStatus(Guid orderId, OrderStatus newStatus);
    }
}