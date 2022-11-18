using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp3.Models
{
    public class Role
    {
        [Required]
        public string Name { get; set; }
    }
}
