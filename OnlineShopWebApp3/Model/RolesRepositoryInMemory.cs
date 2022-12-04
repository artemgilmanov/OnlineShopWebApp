﻿using OnlineShopWebApp3.Areas.Admin.Model;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp3.Model
{
    public class RolesRepositoryInMemory : IRolesRepository
    {
        private readonly List<Role> Roles = new List<Role>();

        public void Add(Role role)
        {
            Roles.Add(role);
        }

        public void Delete(string name)
        {
            var role = Roles.FirstOrDefault(x => x.Name == name);
            Roles.Remove(role);
        }

        public List<Role> GetAll()
        {
            return Roles;
        }

        public Role TryGetByName(string name)
        {
            return Roles.FirstOrDefault(x => x.Name == name);
        }
    }
}