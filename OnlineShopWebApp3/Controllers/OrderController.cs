using Microsoft.AspNetCore.Mvc;

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

        public IActionResult CheckOut()
        {
            var existingCart = _cartsRepository.TryGetByUserId(Constants.UserId);
            _odersRepository.Add(existingCart);
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
