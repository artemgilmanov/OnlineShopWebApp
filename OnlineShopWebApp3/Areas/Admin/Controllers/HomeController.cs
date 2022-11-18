using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp3.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class HomeController : Controller
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IOrdersRepository _ordersRepository;
        private readonly IRolesRepository _rolesRepository;


        public HomeController(IProductsRepository productsRepository, IOrdersRepository ordersRepository, IRolesRepository rolesRepository)
        {
            _productsRepository = productsRepository;
            _ordersRepository = ordersRepository;
            _rolesRepository = rolesRepository;
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
            var roles = _rolesRepository.GetAll();
            return View(roles);
        }

        public IActionResult Users()
        {
            return View();
        }
    }
}
