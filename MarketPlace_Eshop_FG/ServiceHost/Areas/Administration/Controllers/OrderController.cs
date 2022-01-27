using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.DataLayer.DTOs.ProductOrder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceHost.PresentationExtensions;

namespace ServiceHost.Areas.Administration.Controllers
{
    [Authorize("NotContentSection")]
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

        #region User Order Detail Items

        [HttpGet("user-order-detail/{orderId}")]
        public async Task<IActionResult> GetUserOrderDetailItem(long orderId)
        {
            var orderDetailItem = await _orderService.GetUserOrderDetailItem(orderId, User.GetUserId());
            return View(orderDetailItem);
        }

        #endregion

        #region Order Description

        [HttpGet("order-description/{orderId}")]
        public async Task<IActionResult> OrderDescription(long orderId)
        {
            var order = await _orderService.GetOrderForCancel(orderId, User.GetUserId());

            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        #endregion

        #region User Address for Order
        [HttpGet("user-order-address/{orderId}")]
        public async Task<IActionResult> UserOrderAddress(long orderId)
        {
            var userAddress = await _orderService.GetUserAddressForOrder(orderId, User.GetUserId());
            if (userAddress == null)
            {
                return NotFound();
            }
            return View(userAddress);
        }

        #endregion
    }
}
