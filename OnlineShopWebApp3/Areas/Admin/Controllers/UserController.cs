using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp3.Areas.Admin.Model;
using OnlineShopWebApp3.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp3.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]

    public class UserController : Controller
    {
        private readonly UserManager<OnlineShop.Db.Model.User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<OnlineShop.Db.Model.User> usersManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = usersManager;
            _roleManager = roleManager;
        }

        public IActionResult Details(string name)
        {
            var user = _userManager.FindByNameAsync(name).Result;
            return View(user.ToUserViewModel());
        }

        public IActionResult ChangePassword(string userName)
        {
            var changePassword = new ChangePassword()
            {
                UserName = userName
            };

            return View(changePassword);
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePassword newPassword)
        {
            if (newPassword.UserName == newPassword.Password)
            {
                ModelState.AddModelError("", "Password must not be the same as Firstname or Lastname.");
            }

            if (ModelState.IsValid)
            {
                var user = _userManager.FindByNameAsync(newPassword.UserName).Result;
                var newHashPaaword = _userManager.PasswordHasher.HashPassword(user, newPassword.Password);
                user.PasswordHash = newHashPaaword;
                _userManager.UpdateAsync(user).Wait();

                return RedirectToAction(nameof(HomeController.Users), "Home");
            }

            return RedirectToAction(nameof(ChangePassword));
        }

        public IActionResult ChangeEmail(string userName)
        {
            var changeEmail = new ChangeEmail()
            {
                UserName = userName
            };

            return View(changeEmail);
        }

        [HttpPost]
        public IActionResult ChangeEmail(ChangeEmail newEmail)
        {
            if (newEmail.UserName == newEmail.Email)
            {
                ModelState.AddModelError("", "Password must not be the same as Firstname or Lastname.");
            }

            if (ModelState.IsValid)
            {
                var user = _userManager.FindByNameAsync(newEmail.UserName).Result;
                var token = _userManager.GenerateEmailConfirmationTokenAsync(user).Result; // something wrong with token

                _userManager.ChangeEmailAsync(user, newEmail.Email, token).Wait();
                _userManager.UpdateAsync(user).Wait();

                return RedirectToAction(nameof(HomeController.Users), "Home");
            }

            return RedirectToAction(nameof(ChangeEmail));
        }

        public IActionResult Delete(string userName)
        {
            var user = _userManager.FindByNameAsync(userName).Result;
            _userManager.DeleteAsync(user);
            return RedirectToAction(nameof(HomeController.Users), "Home");
        }


        public IActionResult EditRights(string name)
        {
            var user = _userManager.FindByNameAsync(name).Result;
            var userRoles = _userManager.GetRolesAsync(user).Result;
            var roles = _roleManager.Roles.ToList();

            var model = new EditRightsViewModel
            {
                UserName = user.UserName,
                UserRoles = userRoles.Select(x => new RoleViewModel { Name = x }).ToList(),
                AllRoles = roles.Select(x => new RoleViewModel { Name = x.Name }).ToList()
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult EditRights(string name, Dictionary<string, string> userRolesViewModel)
        {
            var userSelectedRoles = userRolesViewModel.Select(x => x.Key);

            var user = _userManager.FindByNameAsync(name).Result;
            var userRoles = _userManager.GetRolesAsync(user).Result;

            _userManager.RemoveFromRolesAsync(user, userRoles).Wait();
            _userManager.AddToRolesAsync(user, userSelectedRoles).Wait();

            //return RedirectToAction(nameof(Details), name);
            return Redirect($"/Admin/User/Details?name={name}");
        }
    }
}
