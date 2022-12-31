using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp3.Areas.Admin.Model
{
    public class RoleViewModel
    {
        [Required]
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            var role = (RoleViewModel)obj;
            return Name == role.Name;
        }
    }
}
