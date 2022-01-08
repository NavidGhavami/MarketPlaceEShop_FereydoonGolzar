using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace ServiceHost.ViewComponents
{
    public class ProductSliderViewComponent : ViewComponent
    {
        #region Constructor

        private readonly IProductService _productService;

        public ProductSliderViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        #endregion

        #region Body

        public async Task<IViewComponentResult> InvokeAsync(string categoryName)
        {
            var category = await _productService.GetProductCategoryByUrlName(categoryName);
            var product = await _productService.GetCategoryProductsByCategoryName(categoryName, 20);
            ViewBag.title = category?.Title;

            return View("ProductSlider", product);
        }

        #endregion
    }
}
