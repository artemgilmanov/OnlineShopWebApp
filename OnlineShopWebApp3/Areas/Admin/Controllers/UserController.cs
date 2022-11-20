using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using OnlineShopWebApp3.Models;

namespace OnlineShopWebApp3.Areas.Admin.Controllers
{
    [Area("Admin")]

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
    }
}
