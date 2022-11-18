using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp3.Models
{
    public enum OrderStatus
    {
        [Display(Name = "Created")]
        Created,
        [Display(Name = "Processed")]
        Processed,
        [Display(Name = "Delivering")]
        Delivering,
        [Display(Name = "Delivered")]
        Delivered,
        [Display(Name = "Canceled")]
        Canceled
    }
}