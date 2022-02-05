using System.Collections.Generic;
using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.DataLayer.Entities.Site;
using Microsoft.AspNetCore.Mvc;
using ServiceHost.PresentationExtensions;

namespace ServiceHost.ViewComponents
{

    #region Constructor

    public class SiteHeaderViewComponent : ViewComponent
    {
        private readonly ISiteService _siteService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;

        public SiteHeaderViewComponent(ISiteService siteService, IProductService productService, IOrderService orderService)
        {
            _siteService = siteService;
            _productService = productService;
            _orderService = orderService;
        }

        #endregion
        
    #region SiteHeader

        public async Task<IViewComponentResult> InvokeAsync()
        {

            ViewBag.siteSetting = await _siteService.GetDefaultSiteSetting();
            ViewBag.ProductCategories = await _productService.GetAllActiveProductCategories();
            return View("SiteHeader");
        }
    }
    #endregion

    #region Get Menu Categories
    public class GetMenuCategoriesViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("GetMenuCategories");
        }
    }


    #endregion

    #region Mobile Menu
    public class MobileMenuViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("MobileMenu");
        }
    }


    #endregion

    #region LoginRegisterModal
    public class LoginRegisterModalViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("LoginRegisterModal");
        }
    }


    #endregion

    #region SiteFooter
    public class SiteFooterViewComponent : ViewComponent
    {
        private readonly ISiteService _siteService;

        public SiteFooterViewComponent(ISiteService siteService)
        {
            _siteService = siteService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.siteSetting = await _siteService.GetDefaultSiteSetting();
            return View("SiteFooter");
        }
    }


    #endregion

    #region ContactUs Address
    public class ContactUsAddressViewComponent : ViewComponent
    {
        private readonly ISiteService _siteService;

        public ContactUsAddressViewComponent(ISiteService siteService)
        {
            _siteService = siteService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.siteSetting = await _siteService.GetDefaultSiteSetting();
            return View("ContactUsAddress");
        }
    }


    #endregion

    #region Slider

    public class HomeSliderViewComponent : ViewComponent
    {
        private readonly ISiteService _siteService;

        public HomeSliderViewComponent(ISiteService siteService)
        {
            _siteService = siteService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var sliders = await _siteService.GetAllActiveSlider();
            return View("HomeSlider", sliders);
        }
    }

    #endregion

    #region SiteBanner_Home1

    public class SiteBannerHome1ViewComponent : ViewComponent
    {
        private readonly ISiteService _siteService;

        public SiteBannerHome1ViewComponent(ISiteService siteService)
        {
            _siteService = siteService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.banners = await _siteService.GetSiteBannersByLocations(new List<SiteBanner.BannersLocations>
            {
                SiteBanner.BannersLocations.Home1,
                SiteBanner.BannersLocations.Home2,
                SiteBanner.BannersLocations.Home3
            });

            return View("SiteBannerHome1");
        }
    }

    #endregion

    #region SiteBanner_Home2

    public class SiteBannerHome2ViewComponent : ViewComponent
    {
        private readonly ISiteService _siteService;

        public SiteBannerHome2ViewComponent(ISiteService siteService)
        {
            _siteService = siteService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.banners = await _siteService.GetSiteBannersByLocations(new List<SiteBanner.BannersLocations>
            {
                SiteBanner.BannersLocations.Home1,
                SiteBanner.BannersLocations.Home2,
                SiteBanner.BannersLocations.Home3
            });

            return View("SiteBannerHome2");
        }
    }

    #endregion

    #region SiteBanner_Home3

    public class SiteBannerHome3ViewComponent : ViewComponent
    {
        private readonly ISiteService _siteService;

        public SiteBannerHome3ViewComponent(ISiteService siteService)
        {
            _siteService = siteService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.banners = await _siteService.GetSiteBannersByLocations(new List<SiteBanner.BannersLocations>
            {
                SiteBanner.BannersLocations.Home1,
                SiteBanner.BannersLocations.Home2,
                SiteBanner.BannersLocations.Home3
            });

            return View("SiteBannerHome3");
        }
    }

    #endregion

    #region User Order

    public class UserOrderViewComponent : ViewComponent
    {
        private readonly IOrderService _orderService;

        public UserOrderViewComponent(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var openOrder = await _orderService.GetUserOpenOrderDetail(User.GetUserId());
            return View("UserOrder", openOrder);
        }
    }

    #endregion

    #region Products with Discount

    public class OffProductsViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public OffProductsViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewData["OffProducts"] = await _productService.GetAllOffProducts(30);
            return View("OffProducts");
        }

    }


    #endregion

    #region Maximum Products View

    public class MaximumProductsViewViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public MaximumProductsViewViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewData["MaximumView"] = await _productService.GetProductWithMaximumView(30);
            return View("MaximumProductsView");
        }

    }

    #endregion

    #region Latest Arrivals Products

    public class LatestArrivalProductsViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public LatestArrivalProductsViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewData["LatestArrivalProducts"] = await _productService.GetLatestArrivalProducts(50);
            return View("LatestArrivalProducts");
        }

    }

    #endregion

    #region Latest Articles

    public class LatestArticlesViewComponent : ViewComponent
    {
        private readonly IBlogService _blogService;

        public LatestArticlesViewComponent(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewData["LatestArticles"] = await _blogService.LatestArticles();
            return View("LatestArticles");
        }

    }

    #endregion

}
