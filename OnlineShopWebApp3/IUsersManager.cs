using OnlineShopWebApp3.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp3
{
    public interface IUsersManager
    {
        void Add(UserAccount userAccount);
        void ChangePassword(string userName, string newPassword);
        List<UserAccount> GetAll();
        UserAccount TryGetByName(string name);
    }
}