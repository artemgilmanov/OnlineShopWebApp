using OnlineShopWebApp3.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp3
{
    public interface IUsersManager
    {
        void Add(UserAccount userAccount);
        List<UserAccount> GetAll();
        UserAccount TryGetByName(string name);
    }
}