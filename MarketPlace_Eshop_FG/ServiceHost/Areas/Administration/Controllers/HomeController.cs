using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.Application.Utilities;
using MarketPlace.DataLayer.DTOs.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.Administration.Controllers
{
    public class HomeController : AdminBaseController
    {
        #region Constructor

        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region Index

        public IActionResult Index()
        {
            return View();
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
                    return RedirectToAction("RoleList", "Home");
            }

            return View();
        }


        #endregion




    }
}
