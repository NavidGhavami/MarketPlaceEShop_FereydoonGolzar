using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ServiceHost.PresentationExtensions;

namespace ServiceHost.Areas.User.ViewComponents
{
    public class UserSidebarDashboardViewComponent : ViewComponent
    {
        private ISellerService _sellerService;

        public UserSidebarDashboardViewComponent(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.hasUserAnyActiveSellerPanel = await _sellerService.HasUserAnyActiveSeller(User.GetUserId());
            return View("UserSidebarDashboard");
        }
    }
}
