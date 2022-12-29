using System;

namespace OnlineShop.Db.Model
{
    public class UserDeliveryInfo
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string CountryCode { get; set; }
        public string Address { get; set; }
        public string AddressOptional { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public bool RememberAddress { get; set; }


    }
}
