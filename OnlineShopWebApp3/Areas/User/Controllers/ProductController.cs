using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp3.Model;
using System;

namespace OnlineShopWebApp3.Areas.User.Controllers
{
    [Area("User")]

    public class ProductController : Controller
    {
        private readonly IProductsRepository _productsRepository;

        public ProductController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public IActionResult Index(Guid id)
        {
            var product = _productsRepository.TryGetById(id);
            return View(product);
        }
    }
}
