using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using GoogleReCaptcha.V3.Interface;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.DataLayer.DTOs.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Controllers
{
    public class AccountController : SiteBaseController
    {
        #region Constructor

        private readonly IUserService _userService;
        private readonly ICaptchaValidator _captchaValidator;
        public AccountController(IUserService userService, ICaptchaValidator captchaValidator)
        {
            _userService = userService;
            _captchaValidator = captchaValidator;
        }

        #endregion

        #region Register

        [HttpGet("register")]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }
            return View();
        }

        [HttpPost("register"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserDTO register)
        {
            if (!await _captchaValidator.IsCaptchaPassedAsync(register.Captcha))
            {
                TempData[ErrorMessage] = "کد کپچای شما تایید نشد";
                return View(register);
            }
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterUser(register);
                switch (result)
                {
                    case RegisterUserResult.MobileExists:
                        TempData[ErrorMessage] = "تلفن همراه وارد شده تکراری می باشد";
                        ModelState.AddModelError("Mobile", "تلفن همراه وارد شده تکراری می باشد ");
                        break;
                    case RegisterUserResult.Success:
                        TempData[SuccessMessage] = "عملیات ثبت نام با موفقیت انجام شد";
                        TempData[InfoMessage] = "کد تایید برای شما ارسال شد";
                        return RedirectToAction("Login");

                }
            }
            return View(register);
        }

        #endregion

        #region Login


        [HttpGet("login")]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }
            return View();
        }

        [HttpPost("login"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserDTO login)
        {

            if (!await _captchaValidator.IsCaptchaPassedAsync(login.Captcha))
            {
                TempData[ErrorMessage] = "کد کپچای شما تایید نشد";
                return View(login);
            }

            if (ModelState.IsValid)
            {
                var result = await _userService.GetUserForLogin(login);

                switch (result)
                {
                    case LoginUserDTO.LoginUserResult.NotFound:
                        TempData[ErrorMessage] = "کاربر مورد نظر یافت نشد";
                        break;
                    case LoginUserDTO.LoginUserResult.NotActivated:
                        TempData[WarningMessage] = "حساب کاربری شما فعال نشده است";
                        break;
                    case LoginUserDTO.LoginUserResult.Success:

                        var user = await _userService.GetUserByMobile(login.Mobile);
                        var claims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.MobilePhone, user.Mobile),
                            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                            new Claim(ClaimTypes.Email, user.Email),
                            new Claim(ClaimTypes.Name, user.FirstName +" "+ user.LastName),



                        };

                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);

                        var properties = new AuthenticationProperties
                        {
                            IsPersistent = login.RememberMe
                        };

                        await HttpContext.SignInAsync(principal, properties);

                        TempData[SuccessMessage] = "شما با موفقیت وارد سایت شدید";
                        return Redirect("/");

                }
            }

            return View();
        }

        #endregion

        #region Forget Password

        [HttpGet("forgot-password")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost("forgot-password"), ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDTO forgot)
        {
            if (!await _captchaValidator.IsCaptchaPassedAsync(forgot.Captcha))
            {
                TempData[ErrorMessage] = "کد کپچای شما تایید نشد";
                return View(forgot);
            }

            if (ModelState.IsValid)
            {
                var result = await _userService.RecoverUserPassword(forgot);

                switch (result)
                {
                    case ForgotPasswordresult.NotFound:
                        TempData[ErrorMessage] = "کاربر مورد نظر یافت نشد";
                        ModelState.AddModelError("Mobile", "کاربر مورد نظر یافت نشد ");
                        break;
                    case ForgotPasswordresult.Success:
                        TempData[SuccessMessage] = " رمز عبور جدید برای شما ارسال شد";
                        TempData[InfoMessage] = "لطفا پس از ورود به حساب کاربری، رمز عبور خود را تغییر دهید";
                        return RedirectToAction("Login");

                }
            }

            return View(forgot);
        }

        #endregion

        #region LogOut

        [HttpGet("log-out")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return Redirect("/");
        }

        #endregion

    }
}
