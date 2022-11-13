using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp3.Models;
using System;

namespace OnlineShopWebApp3.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ProductController : Controller
    {
        private readonly IProductsRepository _productsRepository;

        public ProductController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product newProduct)
        {
            if (!ModelState.IsValid)
            {
                return View(newProduct);
            }

            _productsRepository.Add(newProduct);
            return RedirectToAction("Products", "Home", new { area = "Admin" });
        }

        public IActionResult Update(Guid productId)
        {
            var productToUpdate = _productsRepository.TryGetById(productId);
            return View(productToUpdate);
        }

        [HttpPost]
        public IActionResult Update(Product proproductToReplaceWith)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(proproductToReplaceWith);
            //}

            _productsRepository.Update(proproductToReplaceWith);
            return RedirectToAction("Products", "Home", new { area = "Admin" });
        }

        public IActionResult Delete(Guid productId)
        {
            _productsRepository.Delete(productId);
            return RedirectToAction("Products", "Home", new { area = "Admin" });
        }
    }
}
