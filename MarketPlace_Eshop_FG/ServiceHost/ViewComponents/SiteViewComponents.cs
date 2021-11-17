using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{

    #region SiteHeader
    public class SiteHeaderViewComponent : ViewComponent
    {
        private readonly ISiteService _siteService;

        public SiteHeaderViewComponent(ISiteService siteService)
        {
            _siteService = siteService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            ViewBag.siteSetting = await _siteService.GetDefaultSiteSetting();
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

}
