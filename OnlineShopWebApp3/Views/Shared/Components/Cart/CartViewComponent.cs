using Microsoft.AspNetCore.Mvc;
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
            var productCount = Convert.ToString(cart?.Amount) ?? null;

            return View("Cart", productCount);
        }
    }
}
