using System;
using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.Application.Utilities;
using MarketPlace.DataLayer.DTOs.ProductOrder;
using MarketPlace.DataLayer.DTOs.Shipping;
using Microsoft.AspNetCore.Mvc;
using ServiceHost.PresentationExtensions;

namespace ServiceHost.Areas.Seller.Controllers
{
    public class OrderController : SellerBaseController
    {
        #region Constructor

        private readonly ISellerService _sellerService;
        private readonly IOrderService _orderService;
        private readonly IShippingService _shippingService;
        private readonly IUserService _userService;
        private readonly ISmsService _smsService;

        public OrderController(ISellerService sellerService, IOrderService orderService, IShippingService shippingService, IUserService userService, ISmsService smsService)
        {
            _sellerService = sellerService;
            _orderService = orderService;
            _shippingService = shippingService;
            _userService = userService;
            _smsService = smsService;
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
            var order = await _orderService.GetSellerOrderDetailItem(orderId, seller.Id);

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
                return RedirectToAction("PageNotFound", "Home");
            }
            return View(userAddress);
        }

        #endregion

        #region Shipping Tracking Code List

        [HttpGet("shipping-trackingCode-list/{orderId}")]
        public async Task<IActionResult> GetShippingTrackingCode(long orderId)
        {
            var shippingTrackingCode = await _shippingService.GetShippingTrackingCode(orderId);

            ViewBag.OrderId = orderId;

            return View(shippingTrackingCode);
        }

        #endregion

        #region Create Shipping Tracking Code

        [HttpGet("create-shipping-trackingCode/{orderId}")]
        public async Task<IActionResult> CreateShippingTrackingCode(long orderId)
        {
            return View();
        }

        [HttpPost("create-shipping-trackingCode/{orderId}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateShippingTrackingCode(CreateShippingTrackingCodeDTO tracking, long orderId)
        {
            var userMobile = tracking.Mobile;
            var user = _userService.GetUserById(User.GetUserId());
            var orderTrackingCode = await _orderService.GetOrderBy(orderId);

            var result = await _shippingService.AddShippingTrackingCode(tracking, orderId);

            switch (result)
            {
                case SendTrackingCodeResult.OrderNotFound:
                    TempData[WarningMessage] = "سفارش مورد نظر یافت نشد";
                    break;

                case SendTrackingCodeResult.Error:
                    TempData[ErrorMessage] = "سفارش مورد نظر یافت نشد";
                    break;

                case SendTrackingCodeResult.Success:
                    TempData[SuccessMessage] = "عملیات ارسال کد رهگیری برای سفارش مورد نظر با موفقیت انجام گردید";
                    TempData[InfoMessage] = $"کد رهگیری از طریق پیام کوتاه برای {user.Result.FirstName + " " + user.Result.LastName} ارسال خواهد شد";

                    await _smsService.SendShippingTrackingCode(userMobile, user.Result.FirstName, tracking.TrackingCode, orderTrackingCode, DateTime.Now.ToShamsi());

                    return RedirectToAction("GetShippingTrackingCode", "Order", new { orderId = orderId });
            }
            return View(tracking);
        }

        #endregion

        #region Edit Shipping Tracking Code

        [HttpGet("edit-shipping-tracking-code/{trackingId}")]
        public async Task<IActionResult> EditShippingTrackingCode(long trackingId)
        {
            var trackingCode = await _shippingService.GetShippingTrackingCodeForEdit(trackingId);

            if (trackingCode == null)
            {
                return RedirectToAction("PageNotFound", "Home");
            }

            return View(trackingCode);
        }


        [HttpPost("edit-shipping-tracking-code/{trackingId}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> EditShippingTrackingCode(EditShippingTrackingCodeDTO tracking, long trackingId)
        {
            var userMobile = tracking.Mobile;
            var user = _userService.GetUserById(User.GetUserId());
            var orderTrackingCode = await _orderService.GetOrderBy(tracking.OrderId);

            if (ModelState.IsValid)
            {
                var result = await _shippingService.EditShippingTrackingCode(tracking);

                switch (result)
                {
                    case EditShippingTrackingCodeResult.Error:
                        TempData[ErrorMessage] = "اطلاعات وارد شده یافت نشد";
                        break;

                    case EditShippingTrackingCodeResult.Success:
                        TempData[SuccessMessage] = "ویرایش کد رهگیری مورد نظر با موفقیت انجام گردید";
                        TempData[InfoMessage] = "کد رهگیری از طریق پیام کوتاه مجددا ارسال خواهد شد";

                        await _smsService.SendShippingTrackingCode(userMobile, user.Result.FirstName, tracking.TrackingCode, orderTrackingCode, DateTime.Now.ToShamsi());

                        return RedirectToAction("GetShippingTrackingCode", "Order", new { orderId = tracking.OrderId });

                }
            }


            return View();
        }

        #endregion


    }
}
