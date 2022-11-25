using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp3.Areas.Admin.Model
{
    public class Role
    {
        [Required]
        public string Name { get; set; }
    }
}
