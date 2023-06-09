using System.Collections.Generic;

namespace OnlineShopWebApp3.Helpers
{
    public static class County
    {
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
