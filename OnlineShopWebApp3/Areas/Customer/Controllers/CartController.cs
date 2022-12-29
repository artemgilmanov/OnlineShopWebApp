using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp3.Helpers;
using System;

namespace OnlineShopWebApp3.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartController : Controller
    {
        private readonly ICartsRepository _cartsRepository;
        private readonly IProductsRepository _productsRepository;
        private readonly IFavouriteRepository _favouriteRepository;

        public CartController(ICartsRepository cartsRepository, IProductsRepository productsRepository, IFavouriteRepository favouriteRepository)
        {
            _cartsRepository = cartsRepository;
            _productsRepository = productsRepository;
            _favouriteRepository = favouriteRepository;
        }

        public IActionResult Index()
        {
            var cart = _cartsRepository.TryGetByUserId(Constants.UserId);

            if (cart == null)
            {
                var message = "The cart is empty.";
                ViewBag.EmptyCart = message;
                return View(cart);
            }

            return View(cart.ToCartViewModel());
        }

        public IActionResult Add(Guid productId)
        {
            var product = _productsRepository.TryGetById(productId);

            _cartsRepository.AddProduct(product, Constants.UserId);
            //_favouriteRepository.Remove(product.Id, Constants.UserId);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Increase(Guid productId)
        {
            var product = _productsRepository.TryGetById(productId);
            _cartsRepository.AddProduct(product, Constants.UserId);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Decrease(Guid itemId)
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
