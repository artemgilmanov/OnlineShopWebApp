using OnlineShopWebApp3.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp3
{
    public interface IOrdersRepository
    {
        void Add(Order order);
        List<Order> GetAll();
        Order TryGetById(Guid orderId);
        void UpdateOrderStatus(Guid orderId, OrderStatus newStatus);
    }
}