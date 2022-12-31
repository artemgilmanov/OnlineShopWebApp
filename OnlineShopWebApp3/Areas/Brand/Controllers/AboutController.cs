using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp3.Areas.Brand.Controllers
{
    [Area("Brand")]
    [AllowAnonymous]

    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
