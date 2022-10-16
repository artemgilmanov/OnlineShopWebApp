using Microsoft.AspNetCore.Mvc;
using System;

namespace OnlineShopWebApp3.Controllers
{
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
