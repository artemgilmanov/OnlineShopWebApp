using Microsoft.AspNetCore.Mvc;
using System;

namespace OnlineShopWebApp3.Controllers
{
    public class ProductController : Controller
    {
        //private readonly ProductsRepository productsRepository;

        //public ProductController()
        //{
        //    productsRepository = new ProductsRepository();
        //}

        public IActionResult Index(Guid id)
        {
            var product = ProductsRepository.TryGetById(id);
            return View(product);
        }
    }
}
