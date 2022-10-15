using Microsoft.AspNetCore.Mvc;
using System;

namespace OnlineShopWebApp3.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index(Guid id)
        {
            var product = ProductsRepository.TryGetById(id);
            return View(product);
        }
    }
}
