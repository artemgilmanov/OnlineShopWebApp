using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp3.Helpers

{
    public enum CountryCode
    {
        [Display(Name = "Netherlands")]
        Netherlands = 31,

        [Display(Name = "France")]
        France = 33,

        [Display(Name = "Italy")]
        Italy = 39,

        [Display(Name = "Austria")]
        Austria = 43,

        [Display(Name = "Germany")]
        Germany = 49,
    }
}