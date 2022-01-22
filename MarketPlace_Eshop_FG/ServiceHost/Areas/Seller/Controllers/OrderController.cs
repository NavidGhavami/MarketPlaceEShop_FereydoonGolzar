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
        public async Task<IActionResult> GetOrderForSeller(FilterSellerOrderDTO filter)
        {
            filter.TakeEntity = 10;

            var seller = await _sellerService.GetLastActiveSellerByUserId(User.GetUserId());

            filter.SellerId = seller.Id;

            var order = await _orderService.GetOrderForSeller(filter);
            return View(order);
        }

        #endregion

        #region Seller Order Detail Item

        [HttpGet("seller-order-detail/{orderId}")]
        public async Task<IActionResult> GetOrderDetailItemForSeller(long orderId)
        {
            var seller = await _sellerService.GetLastActiveSellerByUserId(User.GetUserId());
            var order = await _orderService.GetSellerOrderDetailItem(orderId,seller.Id);

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
