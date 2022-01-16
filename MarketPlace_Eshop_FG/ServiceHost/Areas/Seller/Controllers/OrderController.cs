using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.DataLayer.DTOs.ProductOrder;
using Microsoft.AspNetCore.Mvc;
using ServiceHost.PresentationExtensions;

namespace ServiceHost.Areas.Seller.Controllers
{
    public class OrderController : SellerBaseController
    {
        #region Constructor

        private readonly ISellerService _sellerService;
        private readonly IOrderService _orderService;

        public OrderController(ISellerService sellerService, IOrderService orderService)
        {
            _sellerService = sellerService;
            _orderService = orderService;
        }

        #endregion

        #region Seller Order

        [HttpGet("seller-order")]
        public async Task<IActionResult> GetOrderForSeller(FilterUserOrderDTO filter)
        {
            var order = await _orderService.GetOrderForSeller(filter, User.GetUserId());
            return View(order);
        }

        #endregion

        #region Seller Order Detail Item

        [HttpGet("seller-order-detail/{orderId}")]
        public async Task<IActionResult> GetOrderDetailItemForSeller(long orderId)
        {
            var orderDetail = await _orderService.GetSellerOrderDetailItem(orderId, User.GetUserId());

            return View(orderDetail);
        }

        #endregion


    }
}
