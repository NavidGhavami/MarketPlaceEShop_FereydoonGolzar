using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.DataLayer.DTOs.Seller;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceHost.PresentationExtensions;

namespace ServiceHost.Areas.User.Controllers
{
    public class SellerController : UserBaseController
    {
        #region Constructor

        private readonly ISellerService _sellerService;

        public SellerController(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }

        #endregion

        #region Add Seller Request

        [HttpGet("request-seller-panel")]
        public IActionResult RequestSellerPanel()
        {
            return View();
        }

        [HttpPost("request-seller-panel"), ValidateAntiForgeryToken]
        public async Task<IActionResult> RequestSellerPanel(RequestSellerDTO seller, IFormFile logo, IFormFile nationalCard)
        {
            if (ModelState.IsValid)
            {
                var result = await _sellerService.AddNewSellerRequest(seller, User.GetUserId(), logo, nationalCard);

                switch (result)
                {
                    case RequestSellerResult.HasNotPermission:
                        TempData[ErrorMessage] = "شما دسترسی لازم جهت انجام فرایند مورد نظر را ندارید";
                        break;

                    case RequestSellerResult.HasUnderProgressRequest:
                        TempData[WarningMessage] = "درخواست های قبلی شما در حال پیگیری می باشند";
                        TempData[InfoMessage] = "در حال حاضر نمی توانید درخواست جدیدی ثبت نمایید";
                        break;
                    case RequestSellerResult.Success:
                        TempData[SuccessMessage] = "درخواست شما با موفقیت ثبت شد";
                        TempData[InfoMessage] = "فرایند تایید اطلاعات شما در حال پیگیری می باشد";
                        return RedirectToAction("SellerRequests");
                }
            }

            return View(seller);
        }

        #endregion

        #region List of Seller Requests

        [HttpGet("seller-requests")]
        public async Task<IActionResult> SellerRequests(FilterSellerDTO filter)
        {
            filter.TakeEntity = 5;
            filter.UserId = User.GetUserId();
            filter.FilterSellerState = FilterSellerState.All;
            var filterSeller = await _sellerService.FilterSellers(filter);

            return View(filterSeller);
        }


        #endregion

        #region Edit Sellers Requests

        [HttpGet("edit-seller-request/{id}")]
        public async Task<IActionResult> EditSellersRequest(long id)
        {
            var requestSeller = await _sellerService.GetSellerRequestForEdit(id, User.GetUserId());


            if (requestSeller == null)
            {
                return RedirectToAction("PageNotFound", "Home");
            }

            return View(requestSeller);
        }

        [HttpPost("edit-seller-request/{id}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSellersRequest(EditSellerRequestDTO request, IFormFile logo, IFormFile nationalCard)
        {
            if (ModelState.IsValid)
            {
                var result = await _sellerService.EditSellerRequest(request, User.GetUserId(), logo, nationalCard);

                switch (result)
                {
                    case EditSellerRequestResult.NotFound:
                        TempData[ErrorMessage] = "اطلاعات مورد نظر یافت نشد";
                        break;
                    case EditSellerRequestResult.Success:
                        TempData[SuccessMessage] = "اطلاعات مورد نظر با موفقیت ویرایش گردید";
                        TempData[InfoMessage] = "فرآیند تایید اطلاعات دوباره بازبینی می شوند";
                        return RedirectToAction("SellerRequests");
                }
            }

            return View(request);
        }



        #endregion
    }
}
