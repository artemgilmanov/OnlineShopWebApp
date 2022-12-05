using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace OnlineShop.Db.Model
{
    public class Order
    {
        public Guid Id { get; set; }
        public List<CartItem> Items { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}