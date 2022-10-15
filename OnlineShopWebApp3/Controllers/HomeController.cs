using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp3.Models;
using System.Diagnostics;

namespace OnlineShopWebApp3.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            var products = ProductsRepository.GetAll();
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
