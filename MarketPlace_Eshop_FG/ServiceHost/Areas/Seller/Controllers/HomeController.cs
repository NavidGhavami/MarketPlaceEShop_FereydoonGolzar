using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.Seller.Controllers
{
    public class HomeController : SellerBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
