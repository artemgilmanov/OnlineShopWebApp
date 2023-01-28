using System.Text.RegularExpressions;

namespace OnlineShopWebApp3.Areas.Account.Model
{
    public class PhoneNumber
    {
        public string Number { get; set; }
        
        public PhoneNumber(string countryCode, string phoneNumber)
        {
            Number = Format(countryCode,phoneNumber);
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
