using System;
using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.Application.Utilities;
using MarketPlace.DataLayer.DTOs.Account;
using MarketPlace.DataLayer.DTOs.Contact;
using MarketPlace.DataLayer.DTOs.Site;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceHost.PresentationExtensions;

namespace ServiceHost.Areas.Administration.Controllers
{
    public class HomeController : AdminBaseController
    {
        #region Constructor

        private readonly IUserService _userService;
        private readonly ISiteService _siteService;
        private readonly IContactService _contactService;

        public HomeController(IUserService userService, ISiteService siteService, IContactService contactService)
        {
            _userService = userService;
            _siteService = siteService;
            _contactService = contactService;
        }

        #endregion

        #region Index

        public IActionResult Index()
        {
            return View();
        }
        #endregion

        #region Frequently Question

        [HttpGet("frequently-questions")]
        public async Task<IActionResult> FrequentlyQuestionList(FilterFrequentlyQuestionDTO filter)
        {
            var faq = await _siteService.GetFrequentlyQuestions(filter);
            return View(faq);
        }

        [HttpGet("create-frequently-question")]
        public async Task<IActionResult> CreateFrequentlyQuestion()
        {
            return View();
        }

        [HttpPost("create-frequently-question"), ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFrequentlyQuestion(CreatefrequentlyQuestionDTO faq)
        {
            var result = await _siteService.CreateFrequentlyQuestion(faq);

            switch (result)
            {
                case CreateFaqResult.Error:
                    TempData[ErrorMessage] = "در افزودن اطلاعات خطایی رخ داد";
                    break;

                case CreateFaqResult.Success:
                    TempData[SuccessMessage] = "افزودن سوال با موفقیت انجام شد";
                    return RedirectToAction("FrequentlyQuestionList", "Home");
            }

            return View();
        }

        [HttpGet("edit-frequently-question/{faqId}")]
        public async Task<IActionResult> EditFrequentlyQuestion(long faqId)
        {
            var faq = await _siteService.GetFrequentlyQuestionForEdit(faqId);
            return View(faq);
        }

        [HttpPost("edit-frequently-question/{faqId}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> EditFrequentlyQuestion(EditFrequentlyQuestionDTO edit)
        {
            var result = await _siteService.EditFrequentlyQuestion(edit);

            switch (result)
            {
                case EditFrequentlyQuestionResult.NotFound:
                    TempData[WarningMessage] = "اطلاعات مورد نظر یافت نشد";
                    break;
                case EditFrequentlyQuestionResult.Success:
                    TempData[SuccessMessage] = "ویرایش اطلاعات با موفقیت انجام شد";
                    return RedirectToAction("FrequentlyQuestionList", "Home");
            }

            return View();
        }

        #endregion

        #region Seller Guideline

        [HttpGet("seller-guidelines")]
        public async Task<IActionResult> SellerGuidelineList(FilterSellerGuidelineDTO filter)
        {
            var guideline = await _siteService.GetSellerGuidelines(filter);
            return View(guideline);
        }

        [HttpGet("create-seller-guideline")]
        public async Task<IActionResult> CreateSellerGuideline()
        {
            return View();
        }

        [HttpPost("create-seller-guideline"), ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSellerGuideline(CreateSellerGuidelineDTO guideline)
        {
            var result = await _siteService.CreateSellerGuideline(guideline);

            switch (result)
            {
                case CreateSellerGuidelineDTO.CreateSellerGuidelineResult.Error:
                    TempData[ErrorMessage] = "در افزودن اطلاعات خطایی رخ داد";
                    break;

                case CreateSellerGuidelineDTO.CreateSellerGuidelineResult.Success:
                    TempData[SuccessMessage] = "افزودن سوال با موفقیت انجام شد";
                    return RedirectToAction("SellerGuidelineList", "Home");
            }

            return View();
        }

        [HttpGet("edit-seller-guideline/{guidelineId}")]
        public async Task<IActionResult> EditSellerGuideline(long guidelineId)
        {
            var guideline = await _siteService.GetSellerGuidelineForEdit(guidelineId);
            return View(guideline);
        }

        [HttpPost("edit-seller-guideline/{guidelineId}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSellerGuideline(EditSellerGuidelineDTO edit)
        {
            var result = await _siteService.EditSellerGuideline(edit);

            switch (result)
            {
                case EditSellerGuidelineResult.NotFound:
                    TempData[WarningMessage] = "اطلاعات مورد نظر یافت نشد";
                    break;
                case EditSellerGuidelineResult.Success:
                    TempData[SuccessMessage] = "ویرایش اطلاعات با موفقیت انجام شد";
                    return RedirectToAction("SellerGuidelineList", "Home");
            }

            return View();
        }

        #endregion

        #region Site Guideline

        [HttpGet("site-guidelines")]
        public async Task<IActionResult> SiteGuidelineList(FilterSiteGuidelineDTO filter)
        {
            var guideline = await _siteService.GetSiteGuidelines(filter);
            return View(guideline);
        }

        [HttpGet("create-site-guideline")]
        public async Task<IActionResult> CreateSiteGuideline()
        {
            return View();
        }

        [HttpPost("create-site-guideline"), ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSiteGuideline(CreateSiteGuidelineDTO guideline)
        {
            var result = await _siteService.CreateSiteGuideline(guideline);

            switch (result)
            {
                case CreateSiteGuidelineDTO.CreateSiteGuidelineResult.Error:
                    TempData[ErrorMessage] = "در افزودن اطلاعات خطایی رخ داد";
                    break;

                case CreateSiteGuidelineDTO.CreateSiteGuidelineResult.Success:
                    TempData[SuccessMessage] = "افزودن خدمات با موفقیت انجام شد";
                    return RedirectToAction("SiteGuidelineList", "Home");
            }

            return View();
        }

        [HttpGet("edit-site-guideline/{guidelineId}")]
        public async Task<IActionResult> EditSiteGuideline(long guidelineId)
        {
            var guideline = await _siteService.GetSiteGuidelineForEdit(guidelineId);
            return View(guideline);
        }

        [HttpPost("edit-site-guideline/{guidelineId}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSiteGuideline(EditSiteGuidelineDTO edit)
        {
            var result = await _siteService.EditSiteGuideline(edit);

            switch (result)
            {
                case EditSiteGuidelineDTO.EditSiteGuidelineResult.NotFound:
                    TempData[WarningMessage] = "اطلاعات مورد نظر یافت نشد";
                    break;
                case EditSiteGuidelineDTO.EditSiteGuidelineResult.Success:
                    TempData[SuccessMessage] = "ویرایش اطلاعات با موفقیت انجام شد";
                    return RedirectToAction("SiteGuidelineList", "Home");
            }

            return View();
        }

        #endregion

        #region Site Setting

        [HttpGet("site-setting")]
        public async Task<IActionResult> SiteSetting()
        {
            var setting = await _siteService.GetDefaultSiteSetting();
            return View(setting);
        }

        [HttpGet("site-setting/{settingId}")]
        public async Task<IActionResult> EditSiteSetting(long settingId)
        {
            var setting = await _siteService.GetSiteSettingForEdit(settingId);
            return View(setting);
        }

        [HttpPost("site-setting/{settingId}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSiteSetting(EditSiteSettingDTO edit)
        {
            var result = await _siteService.EditSiteSetting(edit);

            switch (result)
            {
                case false:
                    return null;
                case true:
                    return RedirectToAction("SiteSetting", "Home");
            }


        }



        #endregion

        #region ContactUs

        [HttpGet("contact-us-list")]
        public async Task<IActionResult> ContactUsList(FilterContactUs filter)
        {
            var contactUs = await _contactService.FilterContactUs(filter);
            return View(contactUs);
        }

        #endregion

        #region AboutUs

        [HttpGet("about-us")]
        public async Task<IActionResult> AboutUsList()
        {
            var aboutUs = await _contactService.GetAboutUs();
            return View(aboutUs);
        }

        [HttpGet("create-about-us")]
        public async Task<IActionResult> CreateAboutUs()
        {
            return View();
        }

        [HttpPost("create-about-us"), ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAboutUs(CreateAboutUsDTO create, IFormFile aboutImage)
        {
            var result = await _contactService.CreateAboutUs(create, aboutImage);

            switch (result)
            {
                case CreateAboutUsResult.Error:
                    TempData[ErrorMessage] = "در افزودن اطلاعات خطایی رخ داد";
                    break;
                case CreateAboutUsResult.Success:
                    TempData[SuccessMessage] = "عملیات ثبت اطلاعات با موفقیت انجام شد";
                    return RedirectToAction("AboutUsList", "Home");
            }

            return View();
        }

        [HttpGet("edit-about-us/{id}")]
        public async Task<IActionResult> EditAboutUs(long id)
        {
            var result = await _contactService.GetAboutUsForEdit(id);
            return View(result);
        }

        [HttpPost("edit-about-us/{id}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAboutUs(EditAboutUsDTO edit, IFormFile aboutImage)
        {
            var result = await _contactService.EditAboutUs(edit, aboutImage);

            switch (result)
            {
                case EditAboutUsResult.Error:
                    TempData[ErrorMessage] = "فرمت تصویر نادرست می باشد";
                    break;
                case EditAboutUsResult.NotFound:
                    TempData[WarningMessage] = "اطلاعات مورد نظر یافت نشد";
                    break;
                case EditAboutUsResult.Success:
                    TempData[SuccessMessage] = "ویرایش اطلاعات با موفقیت انجام شد";
                    return RedirectToAction("AboutUsList", "Home");

            }

            return View();
        }

        #endregion

        #region Slider

        [HttpGet("list-of-slider")]
        public async Task<IActionResult> SliderList()
        {
            var slider = await _siteService.GetAllSlider();
            return View(slider);
        }

        [HttpGet("create-slider")]
        public async Task<IActionResult> CreateSlider()
        {
            return View();
        }


        [HttpPost("create-slider"), ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSlider(CreateSliderDTO slider, IFormFile sliderImage)
        {
            var result = await _siteService.CreateSlider(slider,sliderImage);

            switch (result)
            {
                case CreateSliderResult.Error:
                    TempData[ErrorMessage] = "در عملیات افزودن اسلایدر خطایی رخ داد";
                    break;
                case CreateSliderResult.Success:
                    TempData[SuccessMessage] = "اسلایدر با موفقیت ایجاد گردید";
                    return RedirectToAction("SliderList", "Home");
            }
            return View();
        }

        [HttpGet("edit-slider/{sliderId}")]
        public async Task<IActionResult> EditSlider(long sliderId)
        {
            var slider = await _siteService.GetSliderForEdit(sliderId);
            return View(slider);

        }

        [HttpPost("edit-slider/{sliderId}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSlider(EditSliderDTO edit, IFormFile sliderImage)
        {
            var result = await _siteService.EditSlider(edit, sliderImage);

            switch (result)
            {
                case EditSliderResult.NotFound:
                    TempData[ErrorMessage] = "اطلاعات مورد نظر یافت نشد";
                    break;
                case EditSliderResult.Success:
                    TempData[SuccessMessage] = "ویرایش اطلاعات با موفقیت انجام شد";
                    return RedirectToAction("SliderList", "Home");
            }
            return View();

        }

        [HttpGet("active-slider/{sliderId}")]
        public async Task<IActionResult> ActiveSlider(long sliderId)
        {
            var slider = await _siteService.ActiveSlider(sliderId);
            return RedirectToAction("SliderList", "Home");
        }
        [HttpGet("deactive-slider/{sliderId}")]
        public async Task<IActionResult> DeactiveSlider(long sliderId)
        {
            var slider = await _siteService.DeactiveSlider(sliderId);
            return RedirectToAction("SliderList", "Home");
        }


        #endregion

        #region Banners

        [HttpGet("banners-list")]
        public async Task<IActionResult> BannerList()
        {
            var banner = await _siteService.GetAllBanners();

            if (banner == null)
            {
                return NotFound();
            }
            return View(banner);
        }

        [HttpGet("create-banner")]
        public async Task<IActionResult> CreateBanner()
        {
            return View();
        }


        [HttpPost("create-banner"), ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBanner(CreateBannerDTO banner, IFormFile bannerImage)
        {
            var result = await _siteService.CreateBanner(banner, bannerImage);

            switch (result)
            {
                case CreateBannerResult.Error:
                    TempData[ErrorMessage] = "در عملیات افزودن بنر خطایی رخ داد";
                    break;
                case CreateBannerResult.Success:
                    TempData[SuccessMessage] = "بنر با موفقیت ایجاد گردید";
                    return RedirectToAction("BannerList", "Home");
            }
            return View();
        }

        [HttpGet("edit-banner/{bannerId}")]
        public async Task<IActionResult> EditBanner(long bannerId)
        {
            var banner = await _siteService.GetBannerForEdit(bannerId);
            return View(banner);
        }

        [HttpPost("edit-banner/{bannerId}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBanner(EditBannerDTO edit, IFormFile bannerImage)
        {
            var result= await _siteService.EditBanner(edit, bannerImage);

            switch (result)
            {
                case EditBannerResult.Error:
                    TempData[ErrorMessage] = "اطلاعات مورد نظر یافت نشد";
                    break;
                case EditBannerResult.Success:
                    TempData[SuccessMessage] = "ویرایش بنر با موفقیت انجام شد";
                    return RedirectToAction("BannerList", "Home");

            }

            return View();

        }


        [HttpGet("active-banner/{bannerId}")]
        public async Task<IActionResult> ActiveBanner(long bannerId)
        {
            var banner = await _siteService.ActiveBanner(bannerId);
            return RedirectToAction("BannerList", "Home");
        }

        [HttpGet("deactive-banner/{bannerId}")]
        public async Task<IActionResult> DeactiveBanner(long bannerId)
        {
            var banner = await _siteService.DeactiveBanner(bannerId);
            return RedirectToAction("BannerList", "Home");
        }

        #endregion

        #region User List
        [Authorize("UserManagement" , Roles = Roles.Administrator)]
        [HttpGet("user-list")]
        public async Task<IActionResult> UserList(FilterUserDTO filter)
        {
            var users = await _userService.FilterUser(filter);

            users.Roles = await _userService.GetRoles();
            ViewBag.roles = users.Roles;

            return View(filter);
        }

        #endregion

        #region Edit User

        [Authorize("UserManagement" , Roles = Roles.Administrator)]
        [HttpGet("edit-user/{userId}")]
        public async Task<IActionResult> EditUser(long userId)
        {
            var user = await _userService.GetUserForEdit(userId);
            if (user == null)
            {
                return NotFound();
            }

            user.Roles = await _userService.GetRoles();
            ViewBag.roles = user.Roles;


            return View(user);
        }

        [HttpPost("edit-user/{userId}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(EditUserDTO edit)
        {
            var result = await _userService.EditUser(edit);


            switch (result)
            {
                case EditUserResult.UserNotFound:
                    TempData[ErrorMessage] = "کاربر مورد نظر یافت نشد";
                    break;
                case EditUserResult.Success:
                    TempData[SuccessMessage] = "ویرایش کاربر با موفقیت انجام شد";
                    return RedirectToAction("UserList", "Home");
            }

            ViewBag.roles = await _userService.GetRoles();
            return View();
        }

        #endregion

        #region Role list
        [Authorize("UserManagement" , Roles = Roles.Administrator)]
        [HttpGet("role-list")]
        public async Task<IActionResult> RoleList(FilterRoleDTO filter)
        {
            var role = await _userService.FilterRole(filter);
            return View(filter);
        }

        #endregion

        #region Add Role

        [Authorize("UserManagement" , Roles = Roles.Administrator)]
        [HttpGet("create-role")]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost("create-role"), ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRole(CreateRoleDTO role)
        {
            var result = await _userService.CreateRole(role);

            switch (result)
            {
                case CreateRoleResult.Error:
                    TempData[ErrorMessage] = "عملیات مورد نظر با خطا مواجه شد";
                    break;
                case CreateRoleResult.Success:
                    TempData[SuccessMessage] = "افزودن نقش با موفقیت انجام شد";
                    return RedirectToAction("RoleList", "Home");
            }

            return View();

        }

        #endregion

        #region Edit Role

        [Authorize("UserManagement" , Roles = Roles.Administrator)]
        [HttpGet("edit-role/{roleId}")]
        public async Task<IActionResult> EditRole(long roleId)
        {
            var role = await _userService.GetRoleForEdit(roleId);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        [HttpPost("edit-role/{roleId}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRole(EditRoleDTO edit)
        {
            var result = await _userService.EditRole(edit);

            switch (result)
            {
                case EditRoleResult.Error:
                    TempData[ErrorMessage] = "در ویرایش اطلاعات خطایی رخ داد";
                    break;
                case EditRoleResult.Success:
                    TempData[SuccessMessage] = "ویرایش نقش با موفقیت انجام شد";
                    return RedirectToAction("RoleList", "Home");;
            }

            return View();
        }


        #endregion

        #region SignOut

        [HttpGet("log-out")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Edit User Profile

        [HttpGet("my-profile")]
        public async Task<IActionResult> GetUserProfile()
        {
            var user = await _userService.GetUserProfile(User.GetUserId());
            return View(user);
        }

        [HttpGet("edit-profile/{userId}")]
        public async Task<IActionResult> EditProfile(long userId)
        {
            var user = await _userService.GetProfileForEdit(userId);
            return View(user);
        }

        [HttpPost("edit-profile/{userId}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(EditUserProfileDTO edit, IFormFile avatarImage)
        {
            var result = await _userService.EditUserProfile(edit, User.GetUserId(), avatarImage);

            switch (result)
            {
                case EditUserProfileResult.NotFound:
                    TempData[WarningMessage] = "مشخصات کاربری شما یافت نشد";
                    break;
                case EditUserProfileResult.Success:
                    TempData[SuccessMessage] = "ویرایش پروفایل من با موفقیت انجام شد";
                    TempData[InfoMessage] = "برای اعمال تغییرات خروج نمایید و مجددا وارد سایت شوید";
                    return RedirectToAction("Index", "Home");
            }

            return View();
        }

        #endregion




    }
}
