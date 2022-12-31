using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp3.Areas.Brand.Model
{
    public class CartViewModel
    {
        public Guid Id { get; set; }

        public List<CartItemViewModel> Items { get; set; }

        public string UserId { get; set; }

        public List<OrderViewModel> Orders { get; set; } = new List<OrderViewModel>();

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
