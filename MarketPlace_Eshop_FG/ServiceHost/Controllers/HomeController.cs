using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Controllers
{
    public class HomeController : SiteBaseController
    {
        #region Constructor



        #endregion

        #region Index
        public IActionResult Index()
        {
            return View();
        }

        #endregion

        #region About Us

        [HttpGet("About-Us")]
        public async Task<IActionResult> AboutUs()
        {
            return View();
        }

        #endregion


    }
}
