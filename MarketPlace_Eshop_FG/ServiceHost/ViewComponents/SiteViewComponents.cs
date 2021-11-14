using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{

    #region SiteHeader
    public class SiteHeaderViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("SiteHeader");
        }
    }


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

    #endregion

    #region SiteFooter
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
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("SiteFooter");
        }
    }


    #endregion

}
