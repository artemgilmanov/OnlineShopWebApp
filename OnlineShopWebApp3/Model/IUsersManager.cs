using OnlineShopWebApp3.Areas.User.Model;
using System.Collections.Generic;

namespace OnlineShopWebApp3.Model
{
    public interface IUsersManager
    {
        void Add(UserAccount userAccount);
        void ChangeEmail(string userName, string newEmail);
        void ChangePassword(string userName, string newPassword);
        void Delete(string userName);
        List<UserAccount> GetAll();
        UserAccount TryGetByName(string name);
    }
}