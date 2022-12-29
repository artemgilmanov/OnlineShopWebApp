using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Model;
using OnlineShopWebApp3.Areas.Customer.Model;
using OnlineShopWebApp3.Helpers;

namespace OnlineShopWebApp3.Areas.Customer.Controllers
{
    [Area("Customer")]

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
        public IActionResult CheckOut(UserDeliveryInfoViewModel userDeliveryInfoViewModel)
        {

            if (!userDeliveryInfoViewModel.IsValidPostcode(userDeliveryInfoViewModel.Postcode))
            {
                ModelState.AddModelError("", "Postcode must have 5 symbols and value between 01000 und 99999.");
            }

            if (userDeliveryInfoViewModel.PhoneNumber.Length < 10)
            {
                ModelState.AddModelError("", "Phone number must have minimum 10 symbols.");
            }

            if (ModelState.IsValid)
            {
                var existingCart = _cartsRepository.TryGetByUserId(Constants.UserId);

                var order = new Order()
                {
                    UserDeliveryInfo = userDeliveryInfoViewModel.ToUserDeliveryInfo(),
                    Items = existingCart.Items
                };

                _odersRepository.Add(order);
                _cartsRepository.Clear(Constants.UserId);

                return RedirectToAction(nameof(SuccessCheckOut));
            }

            return View();
        }
    }
}
