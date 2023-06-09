using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Model;


namespace OnlineShop.Db
{
    public class OrdersDbRepository : IOrdersRepository
    {
        private readonly DataBaseContext _dataBaseContext;
        public OrdersDbRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public void Add(Order order)
        {
            _dataBaseContext.Orders.Add(order);
            _dataBaseContext.SaveChanges();
        }

        public List<Order> GetAll()
        {
            return _dataBaseContext.Orders
                .Include(x => x.UserDeliveryInfo)
                .Include(x => x.Items)
                .ThenInclude(x => x.Product).ToList();
        }

        public Order TryGetById(Guid orderId)
        {
            return _dataBaseContext.Orders
                .Include(x => x.UserDeliveryInfo)
                .Include(x => x.Items).ThenInclude(x => x.Product)
                .FirstOrDefault(x => x.Id == orderId);
        }

        public void UpdateOrderStatus(Guid orderId, OrderStatus newStatus)
        {
            var order = TryGetById(orderId);
            if (order != null)
            {
                order.Status = newStatus;
            }
            _dataBaseContext.SaveChanges();
        }
    }
}
