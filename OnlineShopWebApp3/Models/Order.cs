using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection.Emit;
using System.Xml.Linq;

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