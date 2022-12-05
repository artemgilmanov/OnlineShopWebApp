using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp3.Areas.User.Model;
using OnlineShopWebApp3.Helpers;
using OnlineShopWebApp3.Model;
using System;

namespace OnlineShopWebApp3.Views.Shared.ViewComponents.CartViewComponents
{
    public class CartViewComponent: ViewComponent
    {
        private readonly ICartsRepository _cartsRepository;

        public CartViewComponent(ICartsRepository cartsRepository)
        {
            _cartsRepository = cartsRepository;
        }

        public IViewComponentResult Invoke()
        {
            var cart = _cartsRepository.TryGetByUserId(Constants.UserId);
            var cartViewModel = MappingHelper.ToCartViewModel(cart);
            var productCount = Convert.ToString(cartViewModel?.Amount) ?? null;

            return View("Cart", productCount);
        }
    }
}
