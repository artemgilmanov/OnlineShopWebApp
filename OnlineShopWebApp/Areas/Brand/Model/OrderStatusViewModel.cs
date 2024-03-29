﻿using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp3.Areas.Brand.Model
{
    public enum OrderStatusViewModel
    {
        [Display(Name = "Created")]
        Created,

        [Display(Name = "Processed")]
        Processed,

        [Display(Name = "On the way")]
        Delivering,

        [Display(Name = "Delivered")]
        Delivered,

        [Display(Name = "Canceled")]
        Canceled
    }
}