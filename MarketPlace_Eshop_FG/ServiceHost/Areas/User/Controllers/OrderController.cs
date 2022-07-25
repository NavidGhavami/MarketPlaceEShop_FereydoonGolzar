using System;
using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.Application.Utilities;
using MarketPlace.DataLayer.DTOs.Common;
using MarketPlace.DataLayer.DTOs.ProductOrder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ServiceHost.Http;
using ServiceHost.PresentationExtensions;

namespace ServiceHost.Areas.User.Controllers
{
    public class OrderController : UserBaseController
    {
        #region Constructor

        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly ISmsService _smsService;
        private readonly IPaymentService _paymentService;
        private readonly IConfiguration _configuration;

        private string MerchantId { get; }

        public OrderController(IOrderService orderService, IUserService userService, IPaymentService paymentService, ISmsService smsService ,IConfiguration configuration)
        {
            _orderService = orderService;
            _userService = userService;
            _smsService = smsService;
            _paymentService = paymentService;
            _configuration = configuration;

            MerchantId = _configuration.GetSection("payment")["merchant"];
        }

        #endregion

        #region Add Product to Open order
        [AllowAnonymous]
        [HttpPost("add-product-to-order"), ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProductToOrder(AddProductToOrderDTO order)
        {
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    await _orderService.AddProductToOpenOrder(User.GetUserId(), order);
                    return JsonResponseStatus.SendStatus(
                        JsonResponseStatusType.Success,
                        "محصول مورد نظر با موفقیت ثبت شد",
                        null);
                }

                return JsonResponseStatus.SendStatus(
                    JsonResponseStatusType.Danger,
                    "برای ثبت محصول در سبد خرید ابتدا باید وارد سایت شوید",
                    null);
            }

            return JsonResponseStatus.SendStatus(JsonResponseStatusType.Danger,
                "در ثبت اطلاعات خطایی رخ داد", null);
        }


        #endregion

        #region Open Cart

        [HttpGet("cart/{userId}")]
        public async Task<IActionResult> UserOpenOrder(long userId)
        {
            var openOrder = await _orderService.GetUserOpenOrderDetail(User.GetUserId());
            return View(openOrder);
        }

        #endregion

        #region Pay Order

        [HttpGet("pay-order")]
        public async Task<IActionResult> PayUserOrderPrice()
        {
            var openOrderAmount = await _orderService.GetTotalOrderPriceForPayment(User.GetUserId());

            var siteUrl = _configuration.GetSection("payment")["siteUrl"];
            var callbackUrl = siteUrl + Url.RouteUrl("ZarinpalPaymentResult");
            var redirectUrl = "";

            var status = _paymentService.CreatePaymentRequest(
                MerchantId,
                openOrderAmount,
                "خرید از فروشگاه اینترنتی جیبی سنتر",
                callbackUrl,
                ref redirectUrl
            );

            if (status == PaymentStatus.St100)
            {
                return Redirect(redirectUrl);
            }



            return RedirectToAction("UserOpenOrder", "Order");
        }

        #endregion

        #region call back Zarinpal

        [AllowAnonymous]
        [HttpGet("payment-result", Name = "ZarinpalPaymentResult")]
        public async Task<IActionResult> CallBackZarinPal()
        {
            var authority = _paymentService.GetAuthorityCodeFromCallback(HttpContext);
            var openOrder = _orderService.GetUserLatestOpenOrder(User.GetUserId());
            var userMobile = await _userService.GetUserMobileById(User.GetUserId());
            var user = _userService.GetUserById(User.GetUserId());

            if (openOrder == null)
            {
                return RedirectToAction("PageNotFound", "Home");
            }

            if (authority == "")
            {
                TempData[ErrorMessage] = "عملیات پرداخت با شکست مواجه شد";
                return View();
            }
            var openOrderAmount = await _orderService.GetTotalOrderPriceForPayment(User.GetUserId());
            long refId = 0;
            var trackingCode = CodeGenerator.Generate("JBC_");
            var result = _paymentService.PaymentVerification(MerchantId, authority, openOrderAmount, ref refId);

            if (result == PaymentStatus.St100)
            {
                TempData[SuccessMessage] = "پرداخت شما با موفقیت انجام شد";
                ViewBag.TrackingCode = trackingCode;
                ViewBag.RefId = refId;
                ViewBag.OrderDate = DateTime.Now.ToShamsi();
                await _orderService.PayOrderProductPriceToSeller(User.GetUserId(), refId, trackingCode);
                await _smsService.SendOrderTrackingCodeSms(userMobile, user.Result.FirstName, trackingCode, DateTime.Now.ToShamsi());

                return View();
            }

            TempData[ErrorMessage] = "عملیات پرداخت با خطا مواجه شد";


            return View();
        }

        #endregion

        #region Open Order Partial

        [HttpGet("change-detail-count/{detailId}/{count}")]
        public async Task<IActionResult> ChangeDetailOrderCount(long detailId, int count)
        {

            await _orderService.ChangeOrderDetailCount(detailId, User.GetUserId(), count);
            var openOrder = await _orderService.GetUserOpenOrderDetail(User.GetUserId());
            return PartialView(openOrder);
        }

        #endregion

        #region Remove Product From Cart

        [HttpGet("remove-order-item/{detailId}")]
        public async Task<IActionResult> RemoveProductFromOrder(long detailId)
        {
            var result = await _orderService.RemoveOrderDetail(detailId, User.GetUserId());

            if (result)
            {
                TempData[SuccessMessage] = "محصول مورد نظر از سبد خرید شما حذف شد";
                return JsonResponseStatus.SendStatus(
                    JsonResponseStatusType.Success,
                    "محصول مورد نظر از سبد خرید شما حذف شد",
                    null);
            }

            TempData[ErrorMessage] = "محصول مورد نظر در سبد خرید شما یافت نشد";
            return JsonResponseStatus.SendStatus(
                JsonResponseStatusType.Danger,
                "محصول مورد نظر در سبد خرید شما یافت نشد",
                null);


        }

        #endregion

        #region Add User Address to Order

        [HttpGet("user-address/{userId}")]
        public async Task<IActionResult> AddUserAddress(long userId)
        {
            var userAddress = await _orderService.GetExistUserAddress(userId);
            return View(userAddress);
        }

        [HttpPost("user-address/{userId}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUserAddress(UserAddressDTO address, long userId)
        {
            var openOrder = await _orderService.GetUserLatestOpenOrder(userId);
            address.OrderId = openOrder.Id;

            var result = await _orderService.AddUserAddress(address, User.GetUserId());

            switch (result)
            {
                case AddUserAddressResult.Error:
                    TempData[ErrorMessage] = "ثبت و ذخیره اطلاعات با شکست مواجه شد";
                    break;
                case AddUserAddressResult.OrderExist:
                    TempData[ErrorMessage] = "سفارش خود را مجددا ثبت نمایید";
                    break;
                case AddUserAddressResult.Success:
                    TempData[InfoMessage] = "اطلاعات شما با موفقیت ذخیره و ثبت گردید";
                    return RedirectToAction("PayUserOrderPrice", "Order");
            }

            return View();
        }

        #endregion

        #region User Order List

        [HttpGet("user-order")]
        public async Task<IActionResult> GetUserOrder(FilterUserOrderDTO filter)
        {
            filter.TakeEntity = 5;
            filter.UserId = User.GetUserId();
            filter.FilterUserOrderState = FilterUserOrderState.All;
            

            var userOrder = await _orderService.GetUserOrder(filter);

            return View(userOrder);
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

        #region Cancel Order

        [HttpGet("cancel-order/{orderId}")]
        public async Task<IActionResult> CancelOrder(long orderId)
        {
            var order = await _orderService.GetOrderForCancel(orderId, User.GetUserId());

            if (order == null)
            {
                return RedirectToAction("PageNotFound", "Home");
            }
            return View(order);
        }

        [HttpPost("cancel-order/{orderId}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelOrder(CancelOrderDTO cancel)
        {
            if (ModelState.IsValid)
            {
                var result = await _orderService.CancelOrder(cancel, User.GetUserId());

                switch (result)
                {
                    case CancelOrderResult.OrderNotFound:
                        TempData[WarningMessage] = "سفارش مورد نظر یافت نشد";
                        break;
                    case CancelOrderResult.Error:
                        TempData[ErrorMessage] = "عملیات مورد نظر با خطا مواجه شد";
                        break;
                    case CancelOrderResult.Success:
                        TempData[SuccessMessage] = "سفارش مورد نظر با موفقیت لغو شد";
                        return RedirectToAction("GetUserOrder");
                }
            }



            return View();
        }

        #endregion

        #region Order Description

        [HttpGet("order-description/{orderId}")]
        public async Task<IActionResult> OrderDescription(long orderId)
        {
            var order = await _orderService.GetOrderForCancel(orderId, User.GetUserId());

            if (order == null)
            {
                return RedirectToAction("PageNotFound", "Home");
            }
            return View(order);
        }

        #endregion

        #region User Order Address

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



    }
}
