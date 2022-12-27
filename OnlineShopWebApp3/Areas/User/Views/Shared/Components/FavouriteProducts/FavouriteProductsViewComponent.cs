using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp3.Helpers;
using System;

namespace OnlineShopWebApp3.Areas.User.Controllers
{

    public class FavouriteProductsViewComponent : ViewComponent
    {
        private readonly IFavouriteRepository _favoriteRepository;

        public FavouriteProductsViewComponent(IFavouriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        public IViewComponentResult Invoke()
        {
            var products = _favoriteRepository.GetAll(Constants.UserId);

            return View("FavouriteProducts", products.ToProductViewModels()) ;
        }
       
    }
}
