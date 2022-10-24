using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp3.Models;

namespace OnlineShopWebApp3.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
       
        [HttpPost]
        public IActionResult Create(CreateAccount createAccount)
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
            return RedirectToAction("Index","Home");
        }

    }
}
