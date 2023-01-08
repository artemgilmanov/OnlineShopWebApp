using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp3.Helpers;

namespace OnlineShopWebApp3.Areas.Brand.Controllers
{
    [Area("Brand")]
    [AllowAnonymous]

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

        public IActionResult Filter(string category)
        {
            var products = _productsRepository.TryGetByCategory(category);
            return View(products.ToProductViewModels());
        }
    }
}
