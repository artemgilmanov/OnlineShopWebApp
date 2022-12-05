using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp3.Areas.User.Model;
using OnlineShopWebApp3.Helpers;
using OnlineShopWebApp3.Model;
using System;

namespace OnlineShopWebApp3.Areas.User.Controllers
{
    [Area("User")]

    public class CartController : Controller
    {
        private readonly ICartsRepository _cartsRepository;
        private readonly IProductsRepository _productsRepository;

        public CartController(ICartsRepository cartsRepository, IProductsRepository productsRepository)
        {
            _cartsRepository = cartsRepository;
            _productsRepository = productsRepository;
        }

        public IActionResult Index()
        {
            var cart = _cartsRepository.TryGetByUserId(Constants.UserId);

            if (cart == null)
            {
                var message = "The cart is empty.";
                ViewBag.EmpryCart = message;
                return View(cart);
            }

            return View(cart);
        }

        public IActionResult Add(Guid productId)
        {
            var product = _productsRepository.TryGetById(productId);

            _cartsRepository.AddProduct(product, Constants.UserId);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveItem(Guid itemId)
        {
            _cartsRepository.RemoveItem(itemId, Constants.UserId);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Clear()
        {
            _cartsRepository.Clear(Constants.UserId);
            return RedirectToAction(nameof(Index));
        }

    }
}
