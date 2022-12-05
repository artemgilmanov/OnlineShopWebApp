﻿using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp3.Areas.User.Model;
using OnlineShopWebApp3.Helpers;
using OnlineShopWebApp3.Model;

namespace OnlineShopWebApp3.Areas.User.Controllers
{
    [Area("User")]

    public class OrderController : Controller
    {
        private readonly ICartsRepository _cartsRepository;
        private readonly IOrdersRepository _odersRepository;

        public OrderController(ICartsRepository cartsRepository, IOrdersRepository odersRepository)
        {
            _cartsRepository = cartsRepository;
            _odersRepository = odersRepository;
        }

        public IActionResult SuccessCheckOut()
        {
            var message = "The order completed.";
            ViewBag.Submit = message;

            return View();
        }

        public IActionResult CheckOut()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckOut(UserDeliveryInfo userDeliveryInfo)
        {

            if (!userDeliveryInfo.IsValidPostcode(userDeliveryInfo.Postcode))
            {
                ModelState.AddModelError("", "Postcode must have 5 symbols and value between 01000 und 99999.");
            }

            if (userDeliveryInfo.PhoneNumber.Length < 10)
            {
                ModelState.AddModelError("", "Phone number must have minimum 10 symbols.");
            }

            if (ModelState.IsValid)
            {
                var existingCart = _cartsRepository.TryGetByUserId(Constants.UserId);
                var existingCartViewModel = MappingHelper.ToCartViewModel(existingCart);
                var order = new Order()
                {
                    UserDeliveryInfo = userDeliveryInfo,
                    Items = existingCartViewModel.Items,
                };

                _odersRepository.Add(order);
                _cartsRepository.Clear(Constants.UserId);

                return RedirectToAction(nameof(SuccessCheckOut));
            }

            return View();

        }
    }
}
