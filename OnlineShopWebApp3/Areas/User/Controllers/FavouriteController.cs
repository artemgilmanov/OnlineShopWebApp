using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp3.Helpers;
using System;

namespace OnlineShopWebApp3.Areas.User.Controllers
{
    [Area("User")]

    public class FavouriteController : Controller
    {
        private readonly IFavouriteDbRepository _favoriteRepository;
        private readonly IProductsRepository _productsRepository;

        public FavouriteController(IFavouriteDbRepository favoriteRepository, IProductsRepository productsRepository)
        {
            _favoriteRepository = favoriteRepository;
            _productsRepository = productsRepository;
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

            return View(MappingHelper.ToProductViewModels(products)) ;
        }
        public IActionResult Add(Guid productId)
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
