using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp3.Areas.User.Model
{
    public class UserDeliveryInfoViewModel
    {
        [Required(ErrorMessage = "Please enter Firstname.")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Firstname must have min 2 and max 15 symbols.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Lastname.")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Lastname must have min 2 and max 15 symbols.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter Phone number.")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Phone number must have minimum 10 symbols.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter country phone code.")]
        public string CountryCode { get; set; }

        [Required(ErrorMessage = "Please enter Address.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Address must have min 2 and max 50 symbols.")]
        public string Address { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Address must have min 2 and max 50 symbols.")]
        public string AddressOptional { get; set; }

        [Required(ErrorMessage = "Please enter City.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please chose state.")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter Postcode.")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Postcode must have 5 symbols.")]
        public string Postcode { get; set; }

        public bool RememberAddress { get; set; }

        public bool IsValidPostcode(string postcode)
        {
            if (postcode.Length != 5)
            {
                return false;
            }

            return int.Parse(postcode[1..]) >= 1000
                && int.Parse(postcode) <= 99999;
        }
    }
}
