using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp3.Areas.Brand.Controllers
{
    [Area("Brand")]

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
