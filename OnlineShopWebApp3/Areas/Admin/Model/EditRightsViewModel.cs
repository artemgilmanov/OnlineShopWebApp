using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
