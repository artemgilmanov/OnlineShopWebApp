using OnlineShopWebApp3.Areas.Admin.Model;
using System.Collections.Generic;

namespace OnlineShopWebApp3.Areas.Account.Model
{
    public interface IRolesRepository
    {
        void Add(RoleViewModel role);
        void Delete(string name);
        List<RoleViewModel> GetAll();
        RoleViewModel TryGetByName(string name);
    }
}