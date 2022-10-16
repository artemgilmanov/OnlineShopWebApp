using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp3.Models;
using System;

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

        public IActionResult Add(Guid productId)
        {
            var product = _productsRepository.TryGetById(productId);
            _cartsRepository.Add(product, Constants.UserId);
            return RedirectToAction(nameof(Index));
        }
    }
}
