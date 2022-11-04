using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp3.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class HomeController : Controller
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
