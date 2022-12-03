using System.Text.RegularExpressions;

namespace OnlineShopWebApp3.Areas.User.Model
{
    public class UserAccount
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public UserAccount()
        {

        }
        public UserAccount(Login login)
        {
            Password = login.Password;
            Email = login.Email;
        }
        public UserAccount(UserDeliveryInfo userDeliveryInfo)
        {
            Name = string.Format("{0} {1}", userDeliveryInfo.FirstName, userDeliveryInfo.LastName);
            PhoneNumber = Format(userDeliveryInfo.CountryCode, userDeliveryInfo.PhoneNumber); 
        }

        public string Format(string countryCode, string phoneNumber)
        {
            Regex regex = new Regex(@"[^\d]");
            phoneNumber = regex.Replace(phoneNumber, "");
            phoneNumber = Regex.Replace(phoneNumber, @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3");

            return countryCode + phoneNumber;
        }
    }
}
