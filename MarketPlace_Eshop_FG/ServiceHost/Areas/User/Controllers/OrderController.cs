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
