using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.Seller.ViewComponents
{
    public class SellerSidebarDashboardViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("SellerSidebarDashboard");
        }
    }
}
