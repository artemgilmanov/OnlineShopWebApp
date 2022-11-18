using OnlineShopWebApp3.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp3
{
    public interface IRolesRepository
    {
        void Add(Role role);
        void Delete(string name);
        List<Role> GetAll();
        Role TryGetByName(string name);
    }
}