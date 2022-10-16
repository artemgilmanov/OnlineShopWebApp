using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp3.Models;
using System;
using System.Linq;

namespace OnlineShopWebApp3.Controllers
{
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

            if (cart==null)
            {
                return RedirectToAction(nameof(Empty));
            }

            return View(cart);
        }

        public IActionResult Empty()
        {
            var message = "The cart is empty.";
            ViewBag.EmpryCart = message;
            return View();
        }

        public IActionResult AddToCart(Guid productId)
        {
            var product = _productsRepository.TryGetById(productId);
            _cartsRepository.AddToCart(product, Constants.UserId);
            return RedirectToAction(nameof(Index));
        }
       
        public IActionResult RemoveFromCart(Guid itemId)
        {
            _cartsRepository.RemoveFromCart(itemId);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Clear()
        {
            _cartsRepository.Clear();
            return RedirectToAction(nameof(Index));
        }
    }
}
