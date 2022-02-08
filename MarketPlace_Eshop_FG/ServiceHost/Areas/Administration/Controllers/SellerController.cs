using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.DataLayer.DTOs.Common;
using MarketPlace.DataLayer.DTOs.Seller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceHost.Http;

namespace ServiceHost.Areas.Administration.Controllers
{
    [Authorize("NotContentSection")]
    public class SellerController : AdminBaseController
    {
        #region Constructor

        private readonly ISellerService _sellerService;

        public SellerController(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }

        #endregion

        #region Seller Requests

        [HttpGet("seller-requests")]
        public async Task<IActionResult> SellerRequest(FilterSellerDTO filter)
        {
            var seller = await _sellerService.FilterSellers(filter);

            return View(seller);
        }

        #endregion

        #region Accept Seller Request
        [HttpGet("seller/acceptSellerRequest/{requestId}")]
        public async Task<IActionResult> AcceptSellerRequest(long requestId)
        {
            var result = await _sellerService.AcceptSellerRequest(requestId);

            if (result)
            {
                return JsonResponseStatus.SendStatus(
                    JsonResponseStatusType.Success,
                    "درخواست مورد نظر با موفقیت تایید شد",
                    null
                    );
            }

            return JsonResponseStatus.SendStatus(
                JsonResponseStatusType.Danger,
                "اطلاعاتی با این مشخصات یافت نشد",
                null
                );

        }

        #endregion

        #region Reject Seller Request

        [HttpPost("seller/rejectSellerRequest"), ValidateAntiForgeryToken]
        public async Task<IActionResult> RejectSellerRequest(RejectItemDTO reject)
        {
            if (ModelState.IsValid)
            {
                var result = await _sellerService.RejectSellerRequest(reject);

                if (result)
                {
                    return JsonResponseStatus.SendStatus(
                        JsonResponseStatusType.Success,
                        "درخواست مورد نظر با موفقیت رد شد",
                        reject);
                }
            }

            return JsonResponseStatus.SendStatus(
                JsonResponseStatusType.Danger,
                "اطلاعاتی با این مشخصات یافت نشد",
                null
            );

        }

        #endregion
    }
}
