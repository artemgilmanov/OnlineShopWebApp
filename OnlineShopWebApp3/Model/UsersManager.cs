using OnlineShopWebApp3.Areas.Customer.Model;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp3.Model
{
    public class UsersManager : IUsersManager
    {
        private readonly List<UserAccount> users = new List<UserAccount>();

        public List<UserAccount> GetAll()
        {
            return users;
        }

        public void Add(UserAccount userAccount)
        {
            users.Add(userAccount);
        }

        public UserAccount TryGetByName(string name)
        {
            return users.FirstOrDefault(x => x.Name == name);
        }

        public void ChangePassword(string userName, string newPassword)
        {
            var account = TryGetByName(userName);
            account.Password = newPassword;
        }

        public void ChangeEmail(string userName, string newEmail)
        {
            var account = TryGetByName(userName);
            account.Email = newEmail;

        }

        public void Delete(string userName)
        {
            var user = TryGetByName(userName);
            users.Remove(user);
        }
    }
}