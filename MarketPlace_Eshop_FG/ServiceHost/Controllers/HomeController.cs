using System.Threading.Tasks;
using GoogleReCaptcha.V3.Interface;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.DataLayer.DTOs.Contact;
using Microsoft.AspNetCore.Mvc;
using ServiceHost.PresentationExtensions;

namespace ServiceHost.Controllers
{
    public class HomeController : SiteBaseController
    {
        #region Constructor

        private readonly ISiteService _siteService;
        private readonly IContactService _contactService;
        private readonly ICaptchaValidator _captchaValidator;

        public HomeController(IContactService contactService, ICaptchaValidator captchaValidator, ISiteService siteService)
        {
            _contactService = contactService;
            _captchaValidator = captchaValidator;
            _siteService = siteService;
        }

        #endregion

        #region Index
        public IActionResult Index()
        {
            return View();
        }

        #endregion

        #region ContactUs

        [HttpGet("Contact-Us")]
        public async Task<IActionResult> ContactUs()
        {
            var setting = await _siteService.GetDefaultSiteSetting();
            ViewBag.SiteSetting = setting.MapScript;
            return View();
        }

        [HttpPost("Contact-Us"), ValidateAntiForgeryToken]
        public async Task<IActionResult> ContactUs(CreateContactUsDTO contact)
        {
            if (!await _captchaValidator.IsCaptchaPassedAsync(contact.Captcha))
            {
                TempData[ErrorMessage] = "کد کپچای شما تایید نشد";
                return View(contact);
            }
            if (ModelState.IsValid)
            {
                var ip = HttpContext.GetUserIp();

                await _contactService.CreateContactUs(contact, ip, User.GetUserId());
                TempData[SuccessMessage] = "پیام شما با موفقیت ارسال شد";
                return RedirectToAction("Index", "Home");
            }

            return View(contact);
        }

        #endregion

        #region About Us

        [HttpGet("About-Us")]
        public async Task<IActionResult> AboutUs()
        {
            var data = await _contactService.GetAboutUs();
            return View(data);
        }

        #endregion

        #region Frequently Question

        [HttpGet("frequently-questions")]
        public async Task<IActionResult> FrequentlyQuestions()
        {
            var data = await _siteService.GetAllFrequentlyQuestions();
            return View(data);
        }

        #endregion

        #region 404 NotFound Page

        [HttpGet("404Error-page-not-found")]
        public IActionResult PageNotFound()
        {
            return View();
        }

        #endregion


    }
}
