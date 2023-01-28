using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp3.Areas.Account.Model;
using OnlineShopWebApp3.Areas.Admin.Model;
using OnlineShopWebApp3.Helpers;
using System.Linq;

namespace OnlineShopWebApp3.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]

    public class HomeController : Controller
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IOrdersRepository _ordersRepository;
        private readonly UserManager<OnlineShop.Db.Model.User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public HomeController(IProductsRepository productsRepository, IOrdersRepository ordersRepository, RoleManager<IdentityRole> roleManager, UserManager<OnlineShop.Db.Model.User> userManager)
        {
            _productsRepository = productsRepository;
            _ordersRepository = ordersRepository;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Orders()
        {
            var orders = _ordersRepository?.GetAll();
            return View(orders.Select(x => x.ToOrderViewModel()).ToList());
        }
        
        public IActionResult Products()
        {
            var products = _productsRepository.GetAll();
            return View(products.ToProductViewModels());
        }

        public IActionResult Roles()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles.Select(x => new RoleViewModel {Name = x.Name}).ToList());
        }

        public IActionResult Users()
        {
            var users = _userManager.Users.ToList();
            return View(users.Select(x => x.ToUserViewModel()).ToList());
        }
    }
}
