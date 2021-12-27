using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.DataLayer.DTOs.ProductOrder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceHost.Http;
using ServiceHost.PresentationExtensions;

namespace ServiceHost.Areas.User.Controllers
{
    public class OrderController : UserBaseController
    {
        #region Constructor

        private readonly IOrderService _orderService;
        private readonly IUserService _userService;

        public OrderController(IOrderService orderService, IUserService userService)
        {
            _orderService = orderService;
            _userService = userService;
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



    }
}
