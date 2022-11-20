using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp3.Models;

namespace OnlineShopWebApp3.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersManager _usersManager;

        public AccountController(IUsersManager usersManager)
        {
            _usersManager = usersManager;
        }

        public IActionResult Register()
        {
            return View();
        }
       
        [HttpPost]
        public IActionResult Register(Register register)
        {
            //havent tested
            if (register.FirstName == register.LastName)
            {
                ModelState.AddModelError("", "Firstname and Lastname must be different.");
            }
            //havent tested
            if (register.FirstName == register.Password || register.LastName == register.Password)
            {
                ModelState.AddModelError("", "Password must not be the same as Firstname or Lastname.");
            }

            if (ModelState.IsValid)
            {
                _usersManager.Add(new UserAccount()
                {
                    Name = $"{register.FirstName} {register.LastName}",
                    Password = register.Password,
                    Email=register.Email
                });

                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            //return Content($"{register.FirstName}-{register.LastName}-{register.Password}-{register.Email}");
            return RedirectToAction(nameof(Register));
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (!ModelState.IsValid)
            {
                return Content($"{login.Email}-{login.Password}"); 
            }

            if (login.Email==login.Password)
            {
                ModelState.AddModelError("","E-mail and password must be different.");
                return RedirectToAction(nameof(Login));
            }

            var userAccount = _usersManager.TryGetByName(login.Email);

            if (userAccount == null)
            {
                ModelState.AddModelError("", "The user does not exist.");
                return RedirectToAction(nameof(Login));
            }

            if (userAccount.Password!=login.Password)
            {
                ModelState.AddModelError("", "Wrong password..");
                return RedirectToAction(nameof(Login));
            }

            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController));

        }

    }
}
