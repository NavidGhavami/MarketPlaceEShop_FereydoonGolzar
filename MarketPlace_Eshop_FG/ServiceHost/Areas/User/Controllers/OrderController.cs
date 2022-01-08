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
        private readonly IPaymentService _paymentService;
        private readonly IConfiguration _configuration;

        private string MerchantId { get; }

        public OrderController(IOrderService orderService, IUserService userService, IPaymentService paymentService, IConfiguration configuration)
        {
            _orderService = orderService;
            _userService = userService;
            _paymentService = paymentService;
            _configuration = configuration;

            MerchantId = _configuration.GetSection("payment")["merchant"];
        }

        #endregion

        #region Add Product to Open order
        [AllowAnonymous]
        [HttpPost("add-product-to-order")]
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
                "خرید از فروشگاه اینترنتی ...",
                callbackUrl,
                ref redirectUrl
            );

            if (status == PaymentStatus.St100)
            {
                return Redirect(redirectUrl);
            }



            return RedirectToAction("UserOpenOrder","Order");
        }

        #endregion

        #region call back Zarinpal

        [AllowAnonymous]
        [HttpGet("payment-result", Name = "ZarinpalPaymentResult")]
        public async Task<IActionResult> CallBackZarinPal()
        {
            var authority = _paymentService.GetAuthorityCodeFromCallback(HttpContext);

            if (authority == "")
            {
                TempData[WarningMessage] = "عملیات پرداخت با شکست مواجه شد";
                return View();
            }
            var openOrderAmount = await _orderService.GetTotalOrderPriceForPayment(User.GetUserId());
            long refId = 0;
            var trackingCode = CodeGenerator.Generate("FG_");
            var result = _paymentService.PaymentVerification(MerchantId, authority, openOrderAmount, ref refId);

            if (result == PaymentStatus.St100)
            {
                TempData[SuccessMessage] = "پرداخت شما با موفقیت انجام شد";
                ViewBag.TrackingCode = trackingCode;
                ViewBag.RefId = refId;
                ViewBag.OrderDate = DateTime.Now.ToShamsi();
                await _orderService.PayOrderProductPriceToSeller(User.GetUserId(), refId, trackingCode);

                return View();
            }
            else
            {
                TempData[WarningMessage] = "عملیات پرداخت با خطا مواجه شد";
            }


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



    }
}
