using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHost.Areas.User.Controllers
{
    public class HomeController : UserBaseController
    {
        #region Constructor

        

        #endregion

        #region User Dashboard

        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            return View();
        }

        #endregion
    }
}
