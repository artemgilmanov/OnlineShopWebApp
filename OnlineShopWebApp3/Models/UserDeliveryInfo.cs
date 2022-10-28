using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp3.Models
{
    public class UserDeliveryInfo
    {
        [Required(ErrorMessage = "Please write firstname.")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Firstname must be more than 2 and less than 25 symbols.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please write lastname.")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Lastname must be more than 2 and less than 25 symbols.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please write phone number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please write Address.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Address should have more than 2 and less than 50 symbols.")]
        public string Address { get; set; }
        
        public string AddressOptional { get; set; }

        [Required(ErrorMessage = "Please write city.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please chose state.")]
        public string State { get; set; }

        [Required(ErrorMessage ="Please enter postcode.")]
        [StringLength(10, MinimumLength =6, ErrorMessage = "Postcode should have more than 6 and less than 10 symbols.")]
        public string Postcode { get; set; }
        
        public bool RememberAddress { get; set; }
    }
}
