using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Model;
using OnlineShopWebApp3.Areas.Customer.Model;
using OnlineShopWebApp3.Helpers;
using System;

namespace OnlineShopWebApp3.Areas.Admin.Controllers
{
    //[Area("Admin")]
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]

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
            return View(order.ToOrderViewModel()) ;
        }

        //pass using method
        public IActionResult UpdateOrderStatus(Guid orderId, OrderStatusViewModel status)
        {
           _ordersRepository.UpdateOrderStatus(orderId, (OrderStatus)(int)status);
            return RedirectToAction("Orders", "Home", new { area = "Admin" });
        }
    }
}
