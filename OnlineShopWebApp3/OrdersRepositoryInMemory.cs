using OnlineShopWebApp3.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp3
{
    public class OrdersRepositoryInMemory : IOrdersRepository
    {
        private static List<Cart> orders { get; } = new List<Cart>();

        public void Add(Cart cart)
        {
            orders.Add(cart);
        }

    }
}
