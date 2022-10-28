using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp3.Models
{
    public class Login
    {
        [EmailAddress(ErrorMessage = "Please enter valid e-mail.")]
        [Required(ErrorMessage = "Please enter e-mail.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter password.")]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "The password must have min 8 and max 15 symbols.")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
   
    }
}
