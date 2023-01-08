using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp3.Areas.Admin.Model
{
    public class ChangePassword
    {
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter password.")]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "Password must have min 8 and max 15 symbols.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter password.")]
        [Compare("Password", ErrorMessage = "Passwords don't match.")]
        public string RepeatPasswort { get; set; }
        public List<UserViewModel> Users { get; set; }


    }
}