using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp3.Helpers;
using System;

namespace OnlineShopWebApp3.Areas.Customer.Controllers
{
    [Area("Customer")]

    public class FavouriteController : Controller
    {
        private readonly IFavouriteRepository _favoriteRepository;
        private readonly IProductsRepository _productsRepository;
        private readonly ICartsRepository _cartsRepository;

        public FavouriteController(IFavouriteRepository favoriteRepository, IProductsRepository productsRepository, ICartsRepository cartsRepository)
        {
            _favoriteRepository = favoriteRepository;
            _productsRepository = productsRepository;
            _cartsRepository = cartsRepository;
        }

        public IActionResult FavouriteProducts()
        {
            var products = _favoriteRepository.GetAll(Constants.UserId);

            if (products == null)
            {
                var message = "There is no favourites so far.";
                ViewBag.EmptyFavourites = message;
                return View(products);
            }

            return View(products.ToProductViewModels()) ;
        }

        public IActionResult AddToCard(Guid productId)
        {
            var product = _productsRepository.TryGetById(productId);

            _cartsRepository.AddProduct(product, Constants.UserId);
            _favoriteRepository.Remove(product.Id, Constants.UserId);
            return RedirectToAction("Index", "Cart");
        }
        public IActionResult AddToFavourite(Guid productId)
        {
            var product = _productsRepository.TryGetById(productId);
            _favoriteRepository.Add(Constants.UserId, product);
            return RedirectToAction("Index", "Cart");
        }

        public IActionResult Remove(Guid productId)
        {
            _favoriteRepository.Remove(productId, Constants.UserId);
            return RedirectToAction("Index", "Cart");
        }
    }
}
