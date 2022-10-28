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
            return RedirectToAction("Index", "Home");
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

            return Content($"{login.Email}-{login.Password}-{login.RememberMe}");
        }

    }
}
