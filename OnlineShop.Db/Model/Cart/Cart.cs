using System;
using System.Collections.Generic;

namespace OnlineShop.Db.Model
{
    public class Cart
    {
        public Guid Id { get; set; }

        public List<CartItem> Items { get; set; }

        public string UserId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();

        public Cart()
        {
            CreatedDateTime = DateTime.Now;
            Items = new List<CartItem>();
        }
    }
}
