using OnlineShop.Db.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp3.Areas.User.Model
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }

        public UserDeliveryInfoViewModel UserDeliveryInfo { get; set; }

        public List<CartItemViewModel> Items { get; set; }

        public OrderStatusViewModel Status { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public decimal Cost
        {
            get
            {
                return Items?.Sum(x => x.Cost) ?? 0;
            }
        }

        public OrderViewModel()
        {
            Id = Guid.NewGuid();
            Status = OrderStatusViewModel.Created;
            CreatedDateTime = DateTime.Now;
        }


    }
}