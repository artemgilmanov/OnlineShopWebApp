﻿using System.Reflection.Emit;
using System.Xml.Linq;

namespace OnlineShopWebApp3.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}