using OnlineShopWebApp3.Areas.User.Model;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp3.Model
{
    public interface IOrdersRepository
    {
        void Add(Order order);
        List<Order> GetAll();
        Order TryGetById(Guid orderId);
        void UpdateOrderStatus(Guid orderId, OrderStatus newStatus);
    }
}