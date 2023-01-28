﻿using System;

namespace OnlineShop.Db.Model
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
    }
}