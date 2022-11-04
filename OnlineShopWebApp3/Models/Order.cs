using System;
using System.Collections.Generic;

namespace OnlineShopWebApp3.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        public UserDeliveryInfo UserDeliveryInfo { get; set; }

        public List<CartItem> Items { get; set; }

        public Order()
        {
            Id = Guid.NewGuid();
        }

       
    }
}