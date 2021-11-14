using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.DataLayer.DTOs.Account;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Controllers
{
    public class AccountController : SiteBaseController
    {
        #region Constructor

        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region Register

        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("register"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserDTO register)
        {
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
            return View();
        }

        //public async Task<IActionResult> Login()
        //{
        //    return View();
        //}

        #endregion

    }
}
