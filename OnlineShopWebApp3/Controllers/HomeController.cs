using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp3.Models;
using System.Diagnostics;

namespace OnlineShopWebApp3.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsRepository _productsRepository;
        private readonly ICartsRepository _cartsRepository;



        public HomeController(IProductsRepository productsRepository, ICartsRepository cartsRepository = null)
        {
            _productsRepository = productsRepository;
            _cartsRepository = cartsRepository;
        }

        public IActionResult Index()
        {
            
            var products = _productsRepository.GetAll();
            return View(products);
        }

        public IActionResult Privacy()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
