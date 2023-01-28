using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp3.Helpers;
using System;

namespace OnlineShopWebApp3.Areas.Brand.Controllers
{
    [Area("Brand")]
    [AllowAnonymous]

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
            return View(product.ToProductViewModel());
        }
    }
}
