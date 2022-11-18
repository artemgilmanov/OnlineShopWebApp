using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp3.Models;
using System;

namespace OnlineShopWebApp3.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class OrderController : Controller
    {
        private readonly IOrdersRepository _ordersRepository;

        public OrderController(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public IActionResult Details(Guid orderId)
        {
            var order = _ordersRepository.TryGetById(orderId);
            return View(order);
        }

        //pass using method
        public IActionResult UpdateOrderStatus(Guid orderId, OrderStatus status)
        {
           _ordersRepository.UpdateOrderStatus(orderId, status);
            return RedirectToAction("Orders", "Home", new { area = "Admin" });
        }
    }
}
