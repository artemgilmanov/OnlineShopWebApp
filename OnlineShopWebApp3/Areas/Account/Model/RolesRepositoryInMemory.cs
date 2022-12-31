using OnlineShopWebApp3.Areas.Admin.Model;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp3.Areas.Account.Model
{
    public class RolesRepositoryInMemory : IRolesRepository
    {
        private readonly List<RoleViewModel> Roles = new List<RoleViewModel>();

        public void Add(RoleViewModel role)
        {
            Roles.Add(role);
        }

        public void Delete(string name)
        {
            var role = Roles.FirstOrDefault(x => x.Name == name);
            Roles.Remove(role);
        }

        public List<RoleViewModel> GetAll()
        {
            return Roles;
        }

        public RoleViewModel TryGetByName(string name)
        {
            return Roles.FirstOrDefault(x => x.Name == name);
        }
    }
}