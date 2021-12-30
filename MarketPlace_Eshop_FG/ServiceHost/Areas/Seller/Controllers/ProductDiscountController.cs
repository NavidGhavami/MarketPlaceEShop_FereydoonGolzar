using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.DataLayer.DTOs.ProductDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ServiceHost.PresentationExtensions;

namespace ServiceHost.Areas.Seller.Controllers
{
    public class ProductDiscountController : SellerBaseController
    {
        #region Constructor

        private readonly IProductDiscountService _productDiscountService;
        private readonly ISellerService _sellerService;

        public ProductDiscountController(IProductDiscountService productDiscountService, ISellerService sellerService)
        {
            _productDiscountService = productDiscountService;
            _sellerService = sellerService;
        }

        #endregion

        #region Filter Product Discount

        [HttpGet("discounts")]
        [HttpGet("discounts/{productId}")]
        public async Task<IActionResult> FilterDiscounts(FilterProductDiscountDTO filter)
        {
            var productDiscount = await _productDiscountService.FilterProductDiscount(filter);
            var seller = await _sellerService.GetLastActiveSellerByUserId(User.GetUserId());

            filter.SellerId = seller.Id;

            return View(filter);
        }

        #endregion

        #region Create Discount

        [HttpGet("create-discount")]
        public IActionResult CreateDiscount()
        {
            return View();
        }

        [HttpPost("create-discount"), ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDiscount(CreateDiscountDTO discount)
        {
            if (ModelState.IsValid)
            {
                var seller = await _sellerService.GetLastActiveSellerByUserId(User.GetUserId());
                var result = await _productDiscountService.CreateProductDiscount(discount, seller.Id);

                switch (result)
                {
                    case CreateDiscountResult.Error:
                        TempData[ErrorMessage] = "عملیات ثبت تخفیف مورد نظر با شکست مواجه شد";
                        break;
                    case CreateDiscountResult.ProductNotFound:
                        TempData[WarningMessage] = "محصول مورد نظر یافت نشد";
                        break;
                    case CreateDiscountResult.ProductIsNotForSeller:
                        TempData[WarningMessage] = "محصول مورد نظر یافت نشد";
                        break;
                    case CreateDiscountResult.Success:
                        TempData[SuccessMessage] = "عملیات ثبت تخفیف برای محصول مورد نظر با موفقیت انجام شد";
                        return RedirectToAction("FilterDiscounts");
                }
            }
            return View(discount);
        }

        #endregion

        #region Edit Discount

        [HttpGet("edit-discount/{discountId}")]
        public async Task<IActionResult> EditDiscount(long discountId)
        {
            var discount = await _productDiscountService.GetDiscountForEdit(discountId);
            return View(discount);
        }

        [HttpPost("edit-discount/{discountId}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDiscount(EditDiscountDTO edit, long discountId)
        {
            var seller = await _sellerService.GetLastActiveSellerByUserId(User.GetUserId());

            if (ModelState.IsValid)
            {
                var result = await _productDiscountService.EditProductDiscount(edit, seller.Id);

                switch (result)
                {
                    case EditDiscountResult.ProductNotFound:
                        TempData[WarningMessage] = "محصول مورد نظر یافت نشد";
                        break;
                    case EditDiscountResult.ProductIsNotForSeller:
                        TempData[WarningMessage] = "محصول مورد نظر یافت نشد";
                        break;
                    case EditDiscountResult.Error:
                        TempData[ErrorMessage] = "در ویرایش اطلاعات خطایی رخ داد";
                        break;
                    case EditDiscountResult.Success:
                        TempData[SuccessMessage] = $"ویرایش تخفیف محصول مورد نظر با موفقیت انجام شد";
                        return RedirectToAction("FilterDiscounts");
                        


                }
            }

            return View();
        }


        #endregion
    }
}
