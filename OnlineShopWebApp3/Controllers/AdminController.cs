using Microsoft.AspNetCore.Mvc;

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
