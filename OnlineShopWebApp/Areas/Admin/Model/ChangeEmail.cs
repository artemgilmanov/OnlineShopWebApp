using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp3.Areas.Admin.Model
{
    public class ChangeEmail
    {
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter Email.")]
        [EmailAddress(ErrorMessage = "Email must have @ symbol.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Email.")]
        [Compare("Email", ErrorMessage = "Emails don't match.")]
        public string RepeatEmail { get; set; }
        public List<UserViewModel> Users { get; set; }

    }
}