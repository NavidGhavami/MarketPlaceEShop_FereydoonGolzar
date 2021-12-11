using System.Collections.Generic;
using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.DataLayer.Entities.Site;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{

    #region SiteHeader
    public class SiteHeaderViewComponent : ViewComponent
    {
        private readonly ISiteService _siteService;
        private readonly IProductService _productService;

        public SiteHeaderViewComponent(ISiteService siteService, IProductService productService)
        {
            _siteService = siteService;
            _productService = productService;
        }

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





}
