using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieApplication.Service.Interface;

namespace MovieApplication.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            
            _orderService = orderService;
        }

        // GET: Orders
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = _orderService.GetDetailsForOrder(userId);
      
            return View(model);
        }

        public IActionResult DeleteFromOrder(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _orderService.DeleteTicketFromOrder(userId, id);
            return RedirectToAction("Index", "Orders");

        }
        public IActionResult OrderNow()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _orderService.orderNow(userId);
            return RedirectToAction("Index", "Orders");
        }
    }
}
