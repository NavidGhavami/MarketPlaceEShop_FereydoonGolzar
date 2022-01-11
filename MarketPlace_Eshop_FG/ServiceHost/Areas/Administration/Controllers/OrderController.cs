using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.DataLayer.DTOs.ProductOrder;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.Administration.Controllers
{
    public class OrderController : AdminBaseController
    {
        #region Constructor

        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        #endregion

        #region List of Orders

        [HttpGet("user-order")]
        public async Task<IActionResult> GetOrders(FilterUserOrderDTO filter)
        {
            var orders = await _orderService.GetUserOrder(filter);
            return View(orders);
        }

        #endregion
    }
}
