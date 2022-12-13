﻿using System;

namespace OnlineShopWebApp3.Areas.User.Model
{
    public class CartItemViewModel
    {
        public Guid Id { get; set; }

        public ProductViewModel Product { get; set; }

        public int Amount { get; set; }

        public decimal Cost
        {
            get
            {
                return Amount * Product.Cost;
            }

        }
    }
}