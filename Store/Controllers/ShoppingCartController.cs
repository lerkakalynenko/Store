using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Domain.Core.Entities;
using Store.Services.Interfaces;

namespace Store.Controllers
{
    [Route("cart")]
    public class ShoppingCartController : Controller
    {
        private readonly IOrderService _orderService;

        public ShoppingCartController(IOrderService orderService)
        {
            this._orderService = orderService;
        }

        [Route("index")]
        public ActionResult<List<Order>> Index()
        {
            var cart = _orderService.GetOrders(HttpContext.Session, out var totalPrice);

            ViewBag.Total = totalPrice;

            return View(cart);
        }

        [HttpGet("buy/{id}")]
        public IActionResult Buy(string id)
        {
            _orderService.AddProductToOrder(HttpContext.Session, id);

            return RedirectToAction("Index");
        }

        [HttpGet("remove/{id}")]
        public IActionResult Remove(string id)
        {
            _orderService.RemoveProductFromOrder(HttpContext.Session, id);

            return RedirectToAction("Index");
        }
    }
}
