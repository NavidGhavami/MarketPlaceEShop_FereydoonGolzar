using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.DataLayer.DTOs.Common;
using MarketPlace.DataLayer.DTOs.Products;
using Microsoft.AspNetCore.Mvc;
using ServiceHost.Http;

namespace ServiceHost.Areas.Administration.Controllers
{
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

            var product = await _productService.FilterProducts(filter);

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

    }
}
