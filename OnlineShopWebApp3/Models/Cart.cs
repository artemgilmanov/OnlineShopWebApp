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
        public decimal TotalCost 
        {
            get
            {
                return Items.Sum(x => x.Cost);
            }
                 
        }
      
        public CartItem TryGetByProductId(Guid productId)
        {
            var item = Items.FirstOrDefault(x => x.Product.Id == productId);
            return item;
        }

    }
}
