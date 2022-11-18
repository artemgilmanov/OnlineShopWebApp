using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp3.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class HomeController : Controller
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IOrdersRepository _ordersRepository;

        public HomeController(IProductsRepository productsRepository, IOrdersRepository ordersRepository)
        {
            _productsRepository = productsRepository;
            _ordersRepository = ordersRepository;
        }

        public IActionResult Orders()
        {
            var orders = _ordersRepository?.GetAll();
            return View(orders);
        }

        public IActionResult Products()
        {
            var products = _productsRepository.GetAll();
            return View(products);
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
