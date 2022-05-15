using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.DataLayer.DTOs.Common;
using MarketPlace.DataLayer.DTOs.Seller;
using MarketPlace.DataLayer.DTOs.SellerWallet;
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
        private readonly ISellerWalletService _sellerWalletService;

        public SellerController(ISellerService sellerService, ISellerWalletService sellerWalletService)
        {
            _sellerService = sellerService;
            _sellerWalletService = sellerWalletService;
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

        #region Filter Seller Wallet

        [HttpGet("seller-transactions")]
        public async Task<IActionResult> FilterSellerWallet(FilterSellerWalletDTO filter)
        {
            filter.TakeEntity = 10;

            var filterSellerWallet = await _sellerWalletService.FilterSellerWallet(filter);
            return View(filterSellerWallet);
        }

        #endregion

        #region Settlement Transaction

        [HttpGet("settlement-transaction/{walletId}")]
        public async Task<IActionResult> SettlementTransaction(long walletId)
        {
            var result = await _sellerWalletService.ChangeTransActionTypeInSellerWallet(walletId);

            if (result)
            {
                return JsonResponseStatus.SendStatus(JsonResponseStatusType.Success, "تراکنش مورد نظر تسویه گردید", null);
            }

            return JsonResponseStatus.SendStatus(JsonResponseStatusType.Danger, "تراکنش مورد نظر یافت نشد", null);

        }

        #endregion
    }
}
