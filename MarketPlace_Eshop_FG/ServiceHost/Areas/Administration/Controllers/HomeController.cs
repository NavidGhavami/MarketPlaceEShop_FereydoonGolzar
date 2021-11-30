using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.Administration.Controllers
{
    public class HomeController : AdminBaseController
    {

        #region Index

        public IActionResult Index()
        {
            return View();
        }

        #endregion



    }
}
