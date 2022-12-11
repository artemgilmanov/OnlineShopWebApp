﻿using System;

namespace OnlineShop.Db.Model
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public ProductViewModel Product { get; set; }
        public Cart Cart { get; set; }
        public int Amount { get; set; }
    }
}