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

        #region Product Category

        [HttpGet("product-categories/{parentId}")]
        public async Task<IActionResult> GetProductCategoriesBy(long parentId)
        {
            var categories = await _productService.GetAllProductCategoriesBy(parentId);

            return JsonResponseStatus.SendStatus(JsonResponseStatusType.Success, "اطلاعات دسته بندی ها", categories);
        }

        #endregion

        #region Product

        #region Product List

        [HttpGet("product-list")]
        public async Task<IActionResult> Index(FilterProductDTO filter)
        {
            var seller = await _sellerService.GetLastActiveSellerByUserId(User.GetUserId());

            filter.SellerId = seller.Id;
            filter.ProductState = FilterProductState.All;
            filter = await _productService.FilterProductsInAdmin(filter);


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

        #region Edit Products

        [HttpGet("edit-product/{productId}")]
        public async Task<IActionResult> EditProduct(long productId)
        {
            var product = await _productService.GetProductForEdit(productId);

            if (product == null)
            {
                return NotFound();
            }

            ViewBag.Categories = await _productService.GetAllActiveProductCategories();

            return View(product);
        }

        [HttpPost("edit-product/{productId}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(EditProductDTO edit, long productId, IFormFile productImage)
        {
            if (ModelState.IsValid)
            {
                var result = await _productService.EditSellerProduct(edit, User.GetUserId(), productImage);

                switch (result)
                {
                    case EditProductResult.NotForUser:
                        TempData[WarningMessage] = "در ویرایش اطلاعات خطایی رخ داده است";
                        break;
                    case EditProductResult.NotFound:
                        TempData[ErrorMessage] = "اطلاعات وارد شده یافت نشد";
                        break;
                    case EditProductResult.Success:
                        TempData[SuccessMessage] = $"ویرایش محصول {edit.Title} با موفقیت انجام شد";
                        return RedirectToAction("Index");

                }
            }


            ViewBag.Categories = await _productService.GetAllActiveProductCategories();
            return View();
        }

        #endregion

        #endregion

        #region Product Gallery

        #region Product Gallery List

        [HttpGet("product-gallery/{productId}")]
        public async Task<IActionResult> GetProductGalleries(long productId)
        {
            ViewBag.ProductId = productId;

            var seller = await _sellerService.GetLastActiveSellerByUserId(User.GetUserId());
            var productGallery = await _productService.GetAllProductGalleriesInSellerPanel(productId, seller.Id);

            return View(productGallery);
        }

        #endregion

        #region Create Product Gallery

        [HttpGet("create-product-gallery/{productId}")]
        public async Task<IActionResult> CreateProductGallery(long productId)
        {
            var product = await _productService.GetProductSellerOwnerBy(productId, User.GetUserId());

            if (product == null)
            {
                return NotFound();
            }

            ViewBag.Product = product;
            return View();
        }

        [HttpPost("create-product-gallery/{productId}")]
        public async Task<IActionResult> CreateProductGallery(CreateOrEditProductGalleryDTO gallery, long productId)
        {
            if (ModelState.IsValid)
            {
                var product = await _productService.GetProductSellerOwnerBy(productId, User.GetUserId());

                if (product == null)
                {
                    return NotFound();
                }

                ViewBag.Product = product;

                var seller = await _sellerService.GetLastActiveSellerByUserId(User.GetUserId());
                var result = await _productService.CreateProductGallery(gallery, productId, seller.Id);

                switch (result)
                {
                    case CreateOrEditProductGalleryResult.ImageIsNull:
                        TempData[WarningMessage] = "تصویر مربوطه را وارد نمایید";
                        break;

                    case CreateOrEditProductGalleryResult.NotForUserProduct:
                        TempData[ErrorMessage] = "محصول مورد نظر در لیست محصولات شما یافت نشد";
                        break;

                    case CreateOrEditProductGalleryResult.ProductNotFound:
                        TempData[WarningMessage] = "محصول مورد نظر یافت نشد";
                        break;

                    case CreateOrEditProductGalleryResult.Success:
                        TempData[SuccessMessage] = $"عملیات ثبت گالری برای محصول  {product.Title} با موفقیت انجام شد";
                        return RedirectToAction("GetProductGalleries", "Product", new { productId = productId });
                }
            }

            
            return View(gallery);
        }


        #endregion

        #region Edit Product Gallery

        [HttpGet("product_{productId}/edit-product-gallery/{galleryId}")]
        public async Task<IActionResult> EditProductGallery(long productId, long galleryId)
        {
            var seller = await _sellerService.GetLastActiveSellerByUserId(User.GetUserId());
            var gallery = await _productService.GetProductGalleryForEdit(galleryId, seller.Id);
            if (gallery == null)
            {
                return NotFound();
            }
            
            return View(gallery);
        }

        [HttpPost("product_{productId}/edit-product-gallery/{galleryId}")]
        public async Task<IActionResult> EditProductGallery(CreateOrEditProductGalleryDTO gallery , long galleryId, long productId)
        {
            if (ModelState.IsValid)
            {
                var seller = await _sellerService.GetLastActiveSellerByUserId(User.GetUserId());
                var result = await _productService.EditProductGallery(gallery, galleryId, seller.Id);

                switch (result)
                {
                    case CreateOrEditProductGalleryResult.ProductNotFound:
                        TempData[WarningMessage] = "اطلاعات مورد نظر یافت نشد";
                        break;
                    case CreateOrEditProductGalleryResult.NotForUserProduct:
                        TempData[ErrorMessage] = "این اطلاعات برای شما غیر قابل دسترس می باشد";
                        break;
                    case CreateOrEditProductGalleryResult.ImageIsNull:
                        TempData[WarningMessage] = "تصویر مربوطه را وارد نمایید";
                        break;
                    case CreateOrEditProductGalleryResult.Success:
                        TempData[SuccessMessage] = "اطلاعات مورد نظر با موفقیت ویرایش شد ";
                        return RedirectToAction("GetProductGalleries", "Product", new {productId = productId});
                }
            }

            return View(gallery);
        }

        #endregion

        #endregion


    }
}
