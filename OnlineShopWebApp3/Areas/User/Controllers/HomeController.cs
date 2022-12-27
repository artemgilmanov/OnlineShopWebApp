using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp3.Helpers;

namespace OnlineShopWebApp3.Areas.User.Controllers
{
    [Area("User")]

    public class HomeController : Controller
    {
        private readonly IProductsRepository _productsRepository;

        public HomeController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public IActionResult Index()
        {
            var products = _productsRepository.GetAll();
            return View(products.ToProductViewModels());
        }
    }
}
