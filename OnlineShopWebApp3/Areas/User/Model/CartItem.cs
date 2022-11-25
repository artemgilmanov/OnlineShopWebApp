using System;

namespace OnlineShopWebApp3.Areas.User.Model
{
    public class CartItem
    {
        public Guid Id { get; set; }

        public Product Product { get; set; }

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