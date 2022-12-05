using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp3.Areas.User.Model
{
    public class Order
    {
        public Guid Id { get; set; }

        public UserDeliveryInfo UserDeliveryInfo { get; set; }

        public List<CartItemViewModel> Items { get; set; }

        public OrderStatus Status { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public decimal Cost
        {
            get
            {
                return Items?.Sum(x => x.Cost) ?? 0;
            }
        }

        public Order()
        {
            Id = Guid.NewGuid();
            Status = OrderStatus.Created;
            CreatedDateTime = DateTime.Now;
        }


    }
}