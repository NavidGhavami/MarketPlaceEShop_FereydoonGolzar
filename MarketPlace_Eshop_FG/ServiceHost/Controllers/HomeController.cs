using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Controllers
{
    public class HomeController : SiteBaseController
    {

        

        public IActionResult Index()
        {
            return View();
        }

    }
}
