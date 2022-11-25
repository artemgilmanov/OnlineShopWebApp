using OnlineShopWebApp3.Areas.User.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp3.Model
{
    public class OrdersRepositoryInMemory : IOrdersRepository
    {
        private static List<Order> Orders { get; } = new List<Order>();

        public void Add(Order order)
        {
            Orders.Add(order);
        }

        public List<Order> GetAll()
        {
            return Orders;
        }

        public Order TryGetById(Guid orderId)
        {
            return Orders.FirstOrDefault(x => x.Id == orderId);
        }

        public void UpdateOrderStatus(Guid orderId, OrderStatus newStatus)
        {
            var order = TryGetById(orderId);
            if (order != null)
            {
                order.Status = newStatus;
            }

        }
    }
}
