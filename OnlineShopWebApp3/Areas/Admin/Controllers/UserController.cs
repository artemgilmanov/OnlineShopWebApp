using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp3.Model;
using OnlineShopWebApp3.Models;

namespace OnlineShopWebApp3.Areas.Admin.Controllers
{
    //[Area("Admin")]
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]

    public class UserController : Controller
    {
        private readonly IUsersManager _usersManager;

        public UserController(IUsersManager usersManager)
        {
            _usersManager = usersManager;
        }

        public IActionResult Details(string userName)
        {
            var user = _usersManager.TryGetByName(userName);
            return View(user);
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
                _usersManager.ChangePassword(newPassword.UserName, newPassword.Password);
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
                _usersManager.ChangeEmail(newEmail.UserName, newEmail.Email);
                return RedirectToAction(nameof(HomeController.Users), "Home");
            }

            return RedirectToAction(nameof(ChangeEmail));
        }

        public IActionResult Delete(string userName)
        {

            _usersManager.Delete(userName);
            return RedirectToAction(nameof(HomeController.Users), "Home");

        }
    }
}
