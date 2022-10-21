using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp3.Models;

namespace OnlineShopWebApp3.Controllers
{
    public class AdminController : Controller
    {
      
        public IActionResult Orders()
        {
            return View();
        }
        public IActionResult Products()
        {
            return View();
        }
        public IActionResult Roles()
        {
            return View();
        }
        public IActionResult Users()
        {
            return View();
        }
    }
}
