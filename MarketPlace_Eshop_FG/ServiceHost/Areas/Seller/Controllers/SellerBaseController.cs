using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.Seller.Controllers
{
    [Authorize]
    [Area("Seller")]
    [Route("seller")]
    public class SellerBaseController : Controller
    {
        protected string SuccessMessage = "SuccessMessage";
        protected string WarningMessage = "WarningMessage";
        protected string InfoMessage = "InfoMessage";
        protected string ErrorMessage = "ErrorMessage";
    }
}
