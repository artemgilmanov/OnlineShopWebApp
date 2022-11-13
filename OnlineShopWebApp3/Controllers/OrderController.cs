using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp3.Models;

namespace OnlineShopWebApp3.Controllers
{
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

            if (!userDeliveryInfo.PhoneNumber.StartsWith('+') )
            {
                ModelState.AddModelError("", "Phone number has the following format:+XX(XXX)XXXXXXXX.");
            }

            if (ModelState.IsValid)
            {
                var existingCart = _cartsRepository.TryGetByUserId(Constants.UserId);
                var order = new Order()
                {
                    UserDeliveryInfo = userDeliveryInfo,
                    Items = existingCart.Items,
                };

                _odersRepository.Add(order);
                _cartsRepository.Clear(Constants.UserId);

                return RedirectToAction(nameof(SuccessCheckOut));
            }

            return View();

        }
    }
}
