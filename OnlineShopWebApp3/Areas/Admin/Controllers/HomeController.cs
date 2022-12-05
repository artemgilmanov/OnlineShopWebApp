using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp3.Areas.User.Model;
using OnlineShopWebApp3.Helpers;
using OnlineShopWebApp3.Model;
using System.Collections.Generic;

namespace OnlineShopWebApp3.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class HomeController : Controller
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IOrdersRepository _ordersRepository;
        private readonly IRolesRepository _rolesRepository;
        private readonly IUsersManager _usersManager;


        public HomeController(IProductsRepository productsRepository, IOrdersRepository ordersRepository, IRolesRepository rolesRepository, IUsersManager usersManager)
        {
            _productsRepository = productsRepository;
            _ordersRepository = ordersRepository;
            _rolesRepository = rolesRepository;
            _usersManager = usersManager;
        }

        public IActionResult Orders()
        {
            var orders = _ordersRepository?.GetAll();
            return View(orders);
        }

        public IActionResult Products()
        {
            var products = _productsRepository.GetAll();
            return View(MappingHelper.ToProductViewModels(products));
        }

        public IActionResult Roles()
        {
            var roles = _rolesRepository.GetAll();
            return View(roles);
        }

        public IActionResult Users()
        {
            var usersAccounts = _usersManager.GetAll();
            return View(usersAccounts);
        }
    }
}
