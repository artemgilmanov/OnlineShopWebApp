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

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckOut(UserDeliveryInfo user)
        {
            var existingCart = _cartsRepository.TryGetByUserId(Constants.UserId);
            var order = new Order()
            {
                User=user,
                Items=existingCart.Items,
            };
            _odersRepository.Add(order);
            _cartsRepository.Clear(Constants.UserId);

            return RedirectToAction(nameof(Submit));
        }

        public IActionResult Submit()
        {
            var message = "The order completed.";
            ViewBag.Submit = message;
            return View();
        }


    }
}
