using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.User.ViewComponents
{
    public class UserSidebarDashboardViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("UserSidebarDashboard");
        }
    }
}
