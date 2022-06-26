using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarketPlace.DataLayer.DTOs.Account;
using MarketPlace.DataLayer.Entities.Account;
using Microsoft.AspNetCore.Http;

namespace MarketPlace.Application.Services.Interfaces
{
    public interface IUserService : IAsyncDisposable
    {
        #region Account

        Task<RegisterUserResult> RegisterUser(RegisterUserDTO register);
        Task<bool> IsUserExistsByMobileNumber(string mobile);
        Task<LoginUserDTO.LoginUserResult> GetUserForLogin(LoginUserDTO login);
        Task<User> GetUserByMobile(string mobile);
        Task<User> GetUserById(long userId);
        Task<User> GetUserByUserName(string name);
        Task<ForgotPasswordresult> RecoverUserPassword(ForgotPasswordDTO forgot);
        Task<bool> ActivateMobile(ActivateMobileDTO activate);
        Task<bool> ChangeUserPassword(ChangePasswordDTO changePassword, long currentUserId);
        Task<EditUserProfileDTO> GetProfileForEdit(long userId);
        Task<EditUserProfileResult> EditUserProfile(EditUserProfileDTO profile, long userId, IFormFile avatarImage);
        Task<FilterUserDTO> FilterUser(FilterUserDTO filter);
        Task<EditUserDTO> GetUserForEdit(long userId);
        Task<EditUserResult> EditUser(EditUserDTO edit);
        Task<EditUserProfileDTO> GetUserProfile(long userId);
        Task<string> GetUserMobileById(long userId);

        #endregion

        #region Role

        Task<FilterRoleDTO> FilterRole(FilterRoleDTO filter);
        Task<CreateRoleResult> CreateRole(CreateRoleDTO role);
        Task<EditRoleDTO> GetRoleForEdit(long roleId);
        Task<EditRoleResult> EditRole(EditRoleDTO edit);
        Task<List<Role>> GetRoles();


        #endregion
    }
}
