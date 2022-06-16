using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.Seller.Controllers
{
    public class HomeController : SellerBaseController
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("chat-with-user")]
        public async Task<IActionResult> ChatWithUser()
        {
            return View();
        }
    }
}
