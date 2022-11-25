using OnlineShopWebApp3.Areas.Admin.Model;
using System.Collections.Generic;

namespace OnlineShopWebApp3.Model
{
    public interface IRolesRepository
    {
        void Add(Role role);
        void Delete(string name);
        List<Role> GetAll();
        Role TryGetByName(string name);
    }
}