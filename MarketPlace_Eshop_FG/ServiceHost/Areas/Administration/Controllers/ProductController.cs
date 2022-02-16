using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.DataLayer.DTOs.Common;
using MarketPlace.DataLayer.DTOs.ProductComment;
using MarketPlace.DataLayer.DTOs.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceHost.Http;

namespace ServiceHost.Areas.Administration.Controllers
{
    [Authorize("NotContentSection")]
    public class ProductController : AdminBaseController
    {

        #region Constructor

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        #endregion

        #region Filter Products

        [HttpGet("product-list")]
        public async Task<IActionResult> ProductsList(FilterProductDTO filter)
        {

            var product = await _productService.FilterProductsInAdmin(filter);

            return View(filter);
        }

        #endregion

        #region Accept Product

        [HttpGet("product/acceptSellerProduct/{id}")]
        public async Task<IActionResult> AcceptSellerProduct(long id)
        {
            var result = await _productService.AcceptSellerProduct(id);

            if (result)
            {
                return JsonResponseStatus.SendStatus(JsonResponseStatusType.Success, "محصول مورد نظر با موفقیت تایید شد", null);

            }

            return JsonResponseStatus.SendStatus(JsonResponseStatusType.Danger, "محصول مورد نظر یافت نشد", null);
        }

        #endregion

        #region Reject Product

        [HttpPost("product/rejectSellerProduct"),ValidateAntiForgeryToken]
        public async Task<IActionResult> RejectSellerProduct(RejectItemDTO reject)
        {
            if (ModelState.IsValid)
            {
                var result = await _productService.RejectSellerProduct(reject);

                if (result)
                {
                    return JsonResponseStatus.SendStatus(JsonResponseStatusType.Success, "محصول مورد نظر با موفقیت رد شد", reject);
                }

                return JsonResponseStatus.SendStatus(JsonResponseStatusType.Warning,
                    "اطلاعات مورد نظر جهت عدم تایید را به درستی وارد نمایید", 
                    reject);

            }

            return JsonResponseStatus.SendStatus(JsonResponseStatusType.Danger, "محصول مورد نظر یافت نشد", null);
        }

        #endregion

        #region Product Comment

        [HttpGet("product-comment-list")]
        public async Task<IActionResult> ProductsCommentList(FilterProductCommentDTO filter)
        {

            var productComment = await _productService.FilterProductsComment(filter);

            return View(filter);
        }

        #endregion

        #region Accept Product Comment

        [HttpGet("product-comment/acceptProductComment/{id}")]
        public async Task<IActionResult> AcceptProductComment(long id)
        {
            var result = await _productService.AcceptProductComment(id);

            if (result)
            {
                return JsonResponseStatus.SendStatus(JsonResponseStatusType.Success, "دیدگاه مورد نظر با موفقیت تایید شد", null);

            }

            return JsonResponseStatus.SendStatus(JsonResponseStatusType.Danger, "دیدگاه مورد نظر یافت نشد", null);
        }

        #endregion

        #region Reject Product Comment

        [HttpGet("product-comment/rejectProductComment/{id}")]
        public async Task<IActionResult> RejectProductComment(long id)
        {
            var result = await _productService.RejectProductComment(id);

            if (result)
            {
                return JsonResponseStatus.SendStatus(JsonResponseStatusType.Success, "دیدگاه مورد نظر با موفقیت رد شد", null);

            }

            return JsonResponseStatus.SendStatus(JsonResponseStatusType.Danger, "دیدگاه مورد نظر یافت نشد", null);
        }

        #endregion


    }
}
