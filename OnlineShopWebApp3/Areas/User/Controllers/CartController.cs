using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp3.Helpers;
using System;

namespace OnlineShopWebApp3.Areas.User.Controllers
{
    [Area("User")]
    public class CartController : Controller
    {
        private readonly ICartsRepository _cartsRepository;
        private readonly IProductsRepository _productsRepository;
        private readonly IFavouriteDbRepository _favouriteDbRepository;

        public CartController(ICartsRepository cartsRepository, IProductsRepository productsRepository, IFavouriteDbRepository favouriteDbRepository)
        {
            _cartsRepository = cartsRepository;
            _productsRepository = productsRepository;
            _favouriteDbRepository = favouriteDbRepository;
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

            return View(MappingHelper.ToCartViewModel(cart));
        }

        public IActionResult Add(Guid productId)
        {
            var product = _productsRepository.TryGetById(productId);

            _cartsRepository.AddProduct(product, Constants.UserId);
            _favouriteDbRepository.Remove(product.Id, Constants.UserId);
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
