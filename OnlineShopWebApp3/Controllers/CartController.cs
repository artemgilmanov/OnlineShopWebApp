using Microsoft.AspNetCore.Mvc;
using System;

namespace OnlineShopWebApp3.Controllers
{
    public class CartController : Controller
    {
        
        public IActionResult Index()
        {
            var cart = CartsRepository.TryGetByUserId(Constants.UserId);

            if (cart==null)
            {
                return RedirectToAction(nameof(Empty));
            }

            var message = "The cart is not empty.";
            ViewBag.NotEmpryCart = message;

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
            CartsRepository.Add(productId, Constants.UserId);
            return RedirectToAction(nameof(Index));
        }
    }
}
