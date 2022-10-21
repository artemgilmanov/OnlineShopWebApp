using OnlineShopWebApp3.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp3
{
    public class OrdersRepositoryInMemory : IOrdersRepository
    {
        private static List<Order> orders { get; } = new List<Order>();

        public void Add(Order order)
        {
            orders.Add(order);
        }

    }
}
