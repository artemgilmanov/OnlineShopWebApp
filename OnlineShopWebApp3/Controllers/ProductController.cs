using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp3.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
