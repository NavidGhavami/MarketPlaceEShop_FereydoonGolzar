using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.DataLayer.DTOs.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceHost.Http;
using ServiceHost.PresentationExtensions;

namespace ServiceHost.Areas.Seller.Controllers
{
    public class ProductController : SellerBaseController
    {
        #region Constructor

        private readonly IProductService _productService;
        private readonly ISellerService _sellerService;

        public ProductController(IProductService productService, ISellerService sellerService)
        {
            _productService = productService;
            _sellerService = sellerService;
        }
        #endregion

        #region Product List

        [HttpGet("product-list")]
        public async Task<IActionResult> Index(FilterProductDTO filter)
        {
            var seller = await _sellerService.GetLastActiveSellerByUserId(User.GetUserId());

            filter.SellerId = seller.Id;
            filter.ProductState = FilterProductState.All;
            filter = await _productService.FilterProducts(filter);


            return View(filter);
        }

        #endregion

        #region Create Product

        [HttpGet("create-product")]
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.Categories = await _productService.GetAllActiveProductCategories();

            return View();
        }

        [HttpPost("create-product"), ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(CreateProductDTO product, IFormFile productImage)
        {
            if (ModelState.IsValid)
            {
                var seller = await _sellerService.GetLastActiveSellerByUserId(User.GetUserId());
                var result = await _productService.CreateProduct(product, seller.Id, productImage);

                switch (result)
                {
                    case CreateProductResult.HasNoImage:
                        TempData[WarningMessage] = "لطفا تصویر محصول را آپلود نمایید";
                        break;
                    case CreateProductResult.Error:
                        TempData[ErrorMessage] = "عملیات ثبت محصول با خطا مواجه شد";
                        break;
                    case CreateProductResult.Success:
                        TempData[SuccessMessage] = $"محصول مورد نظر با عنوان {product.Title} با موفقیت ثبت شد";
                        return RedirectToAction("Index");
                }

            }


            ViewBag.Categories = await _productService.GetAllActiveProductCategories();
            return View(product);
        }

        #endregion

        #region Product Category

        [HttpGet("product-categories/{parentId}")]
        public async Task<IActionResult> GetProductCategoriesBy(long parentId)
        {
            var categories = await _productService.GetAllProductCategoriesBy(parentId);

            return JsonResponseStatus.SendStatus(JsonResponseStatusType.Success, "اطلاعات دسته بندی ها", categories);
        }

        #endregion


    }
}
