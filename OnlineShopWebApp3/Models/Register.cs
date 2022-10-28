using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp3.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Please write Firstname.")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Firstname should have more that 2 and less tham 25 symbols.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please write Lastname.")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Lastname should have more that 2 and less tham 25 symbols.")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Please enter valid e-mail.")]
        [Required(ErrorMessage = "Please enter e-mail.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter password.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords don't match.")]
        [Required(ErrorMessage = "Please enter password.")]
        public string RepeatPasswort { get; set; }
    }
}