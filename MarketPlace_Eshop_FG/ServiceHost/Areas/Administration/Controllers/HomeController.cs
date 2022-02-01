using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.Application.Utilities;
using MarketPlace.DataLayer.DTOs.Account;
using MarketPlace.DataLayer.DTOs.Contact;
using MarketPlace.DataLayer.DTOs.Site;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("site-setting/{settingId}")]
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

        [HttpPost("create-about-us")]
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

        [HttpPost("edit-about-us/{id}")]
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


        [HttpPost("create-slider")]
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

        [HttpPost("edit-slider/{sliderId}")]
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


        [HttpPost("create-banner")]
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

        [HttpPost("edit-banner/{bannerId}")]
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

        [HttpPost("edit-user/{userId}")]
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




    }
}
