using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.DataLayer.DTOs.ProductComment;
using MarketPlace.DataLayer.DTOs.Products;
using Microsoft.AspNetCore.Mvc;
using ServiceHost.PresentationExtensions;

namespace ServiceHost.Controllers
{
    public class ProductController : SiteBaseController
    {
        #region Constructor

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        #endregion

        #region Filter Product

        [HttpGet("products")]
        [HttpGet("products/{Category}")]
        public async Task<IActionResult> FilterProducts(FilterProductDTO filter)
        {
            filter.TakeEntity = 12;
            filter = await _productService.FilterProducts(filter);
            ViewBag.ProductCategories = await _productService.GetAllActiveProductCategories();

            if (filter.PageId > filter.GetLastPage() && filter.GetLastPage() != 0)
            {
                return RedirectToAction("PageNotFound", "Home");
            }

            return View(filter);
        }

        #endregion

        #region Search Products

        [HttpGet("search-products")]
        [HttpGet("search-products/{Category}")]
        public async Task<IActionResult> SearchProducts(FilterProductDTO filter, string productTitle, string storeName)
        {
            if (!string.IsNullOrEmpty(productTitle) || !string.IsNullOrEmpty(storeName))
            {
                filter.TakeEntity = 12;
                filter.ProductTitle = productTitle;
                filter.StoreName = storeName;
                filter = await _productService.SearchProducts(filter);

                ViewBag.ProductCategories = await _productService.GetAllActiveProductCategories();

                if (filter.PageId > filter.GetLastPage() && filter.GetLastPage() != 0)
                {
                    return RedirectToAction("PageNotFound", "Home");
                }
                return View(filter);

            }
            else
            {
                TempData[WarningMessage] = "عنوان جستجو نمی تواند خالی باشد. لطفا نام محصول یا نام فروشگاه مورد نظر را وارد نمایید";
                return RedirectToAction("Index", "Home");
            }

        }

        #endregion

        #region Show Product Details

        [HttpGet("products/{productId}/{title}")]
        public async Task<IActionResult> ProductDetails(long productId, string title)
        {
            var product = await _productService.GetProductDetailsBy(productId);

            if (product == null)
            {
                return RedirectToAction("PageNotFound", "Home");
            }

            return View(product);
        }

        #endregion

        #region Add Product Comment

        [HttpPost("add-comment")]
        public async Task<IActionResult> AddProductComment(AddProductCommentDTO comment, long productId, string commentFeature, string fullname, string email, string commentText)
        {
            var userId = User.GetUserId();

            comment.ProductId = productId;
            comment.UserId = userId;
            comment.CommentFeature = commentFeature;
            comment.FullName = fullname;
            comment.Email = email;
            comment.CommentText = commentText;

            var result = await _productService.AddComment(comment, productId, userId);

            switch (result)
            {
                case AddProductCommentResult.Error:
                    TempData[ErrorMessage] = "در ارسال دیدگاه خطایی رخ داد. لطفا دوباره امتحان نمایید";
                    break;
                case AddProductCommentResult.Success:
                    TempData[SuccessMessage] = "ارسال دیدگاه با موفقیت انجام شد. با تشکر از شما بابت ارسال دیدگاه ارزشمندتان";
                    return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}
