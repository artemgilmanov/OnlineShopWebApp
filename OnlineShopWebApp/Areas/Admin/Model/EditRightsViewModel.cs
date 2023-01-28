using System.Collections.Generic;

namespace OnlineShopWebApp3.Areas.Admin.Model
{
    public class EditRightsViewModel
    {
        public string  UserName { get; set; }
        public List<RoleViewModel> UserRoles { get; set; }
        public List<RoleViewModel> AllRoles { get; set; }
        public List<UserViewModel> Users { get; set; }
    }
}
