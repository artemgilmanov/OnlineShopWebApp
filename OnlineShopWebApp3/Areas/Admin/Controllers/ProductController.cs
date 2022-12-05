using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Model;
using OnlineShopWebApp3.Areas.User.Model;
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
        public IActionResult Add(ProductViewModel newProduct)
        {
            if (!ModelState.IsValid)
            {
                return View(newProduct);
            }

            var productDb = new Product()
            {
                Name = newProduct.Name,
                Cost = newProduct.Cost,
                Description = newProduct.Description
            };

            _productsRepository.Add(productDb);
            return RedirectToAction("Products", "Home", new { area = "Admin" });
        }

        public IActionResult Update(Guid productId)
        {
            var productToUpdate = _productsRepository.TryGetById(productId);
            return View(productToUpdate);
        }

        [HttpPost]
        public IActionResult Update(ProductViewModel proproductToReplaceWith)
        {
            if (!ModelState.IsValid)
            {
                return View(proproductToReplaceWith);
            }

            var productDb = new Product()
            {
                Name = proproductToReplaceWith.Name,
                Cost = proproductToReplaceWith.Cost,
                Description = proproductToReplaceWith.Description
            };

            _productsRepository.Update(productDb);
            return RedirectToAction("Products", "Home", new { area = "Admin" });
        }

        public IActionResult Delete(Guid productId)
        {
            _productsRepository.Delete(productId);
            return RedirectToAction("Products", "Home", new { area = "Admin" });
        }
    }
}
