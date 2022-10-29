using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp3.Models;

namespace OnlineShopWebApp3.Controllers
{
    public class AccountController : Controller
    {
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
                return RedirectToAction("Index", "Home");
            }

            return Content($"{register.FirstName}-{register.LastName}-{register.Password}-{register.Email}");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (login.Email==login.Password)
            {
                ModelState.AddModelError("","E-mail and password must be different.");
            }

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }

            return Content($"{login.Email}-{login.Password}");
        }

    }
}
