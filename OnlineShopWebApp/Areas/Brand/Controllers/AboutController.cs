using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp3.Areas.Brand.Model;

namespace OnlineShopWebApp3.Areas.Brand.Controllers
{
    [Area("Brand")]
    [AllowAnonymous]

    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View(new AboutViewModel());
        }
    }
}
