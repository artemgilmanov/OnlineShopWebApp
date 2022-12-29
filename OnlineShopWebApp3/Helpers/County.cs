using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace OnlineShopWebApp3.Helpers
{
    public static class County
    {
        public enum Code
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

        public static List<string> States
        {
            get
            {
                var states = new List<string>()
                {
                    "Berlin",
                    "Bavaria",
                    "Lower Saxony",
                    "Baden-Württemberg",
                    "Rhineland-Palatinate",
                    "Saxony",
                    "Thuringia",
                    "Hessen",
                    "North Rhine-Westphalia",
                    "Saxony-Anhalt",
                    "Brandenburg",
                    "Mecklenburg-Vorpommern",
                    "Hamburg",
                    "Schleswig-Holstein",
                    "Saarland",
                    "Bremen"
                };

                return states;
            }
        }
    }
}
