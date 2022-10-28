using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp3.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public List<CartItem> Items { get; set; }
        public string UserId { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
        public decimal TotalCost 
        {
            get
            {
                return Items?.Sum(x => x.Cost) ?? 0;
            }
        }
        public decimal Amount
        {
            get
            {
                return Items?.Sum(x => x.Amount) ?? 0;
            }
        }
    }
}
