using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MarketPlace.Application.Extensions;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.Application.Utilities;
using MarketPlace.DataLayer.DTOs.Account;
using MarketPlace.DataLayer.Entities.Account;
using MarketPlace.DataLayer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Application.Services.Implementations
{
    public class UserService : IUserService
    {

        #region Constructor

        private readonly IGenericRepository<User> _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ISmsService _smsService;
        public UserService(IGenericRepository<User> userRepository, IPasswordHasher passwordHasher, ISmsService smsService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _smsService = smsService;
        }

        #endregion


        #region Account

        public async Task<RegisterUserResult> RegisterUser(RegisterUserDTO register)
        {

            try
            {
                if (!await IsUserExistsByMobileNumber(register.Mobile))
                {
                    var user = new User
                    {
                        FirstName = register.FirstName,
                        LastName = register.LastName,
                        Mobile = register.Mobile,
                        Email = register.Email,
                        Password = _passwordHasher.EncodePasswordMd5(register.Password),
                        MobileActiveCode = new Random().Next(100000, 999999).ToString(),
                        EmailActiveCode = Guid.NewGuid().ToString("N")

                    };

                    await _userRepository.AddEntity(user);
                    await _userRepository.SaveChanges();

                    await _smsService.SendVerificationSms(register.Mobile, user.MobileActiveCode);

                    return RegisterUserResult.Success;
                }
                else
                {
                    return RegisterUserResult.MobileExists;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return RegisterUserResult.Error;





        }

        public async Task<bool> IsUserExistsByMobileNumber(string mobile)
        {
            return await _userRepository.GetQuery().AsQueryable().AnyAsync(x => x.Mobile == mobile);
        }

        public async Task<LoginUserDTO.LoginUserResult> GetUserForLogin(LoginUserDTO login)
        {
            var user = await _userRepository.GetQuery().AsQueryable()
                .SingleOrDefaultAsync(x => x.Mobile == login.Mobile);

            if (user == null)
            {
                return LoginUserDTO.LoginUserResult.NotFound;
            }

            if (!user.IsMobileActive)
            {
                return LoginUserDTO.LoginUserResult.NotActivated;
            }

            if (user.Password != _passwordHasher.EncodePasswordMd5(login.Password))
            {
                return LoginUserDTO.LoginUserResult.NotFound;
            }

            return LoginUserDTO.LoginUserResult.Success;
        }

        public async Task<User> GetUserByMobile(string mobile)
        {
            return await _userRepository.GetQuery().AsQueryable().SingleOrDefaultAsync(x => x.Mobile == mobile);
        }

        public async Task<ForgotPasswordresult> RecoverUserPassword(ForgotPasswordDTO forgot)
        {
            var user = await _userRepository.GetQuery().SingleOrDefaultAsync(x => x.Mobile == forgot.Mobile);

            if (user == null)
            {
                return ForgotPasswordresult.NotFound;
            }

            var newPassword = PasswordGenerator.CreateRandomPassword();
            user.Password = _passwordHasher.EncodePasswordMd5(newPassword);
            _userRepository.EditEntity(user);

            await _smsService.SendRecoverPasswordSms(user.Mobile, newPassword);

            await _userRepository.SaveChanges();

            return ForgotPasswordresult.Success;
        }

        public async Task<bool> ActivateMobile(ActivateMobileDTO activate)
        {
            var user = await _userRepository.GetQuery().AsQueryable()
                .SingleOrDefaultAsync(x => x.Mobile == activate.Mobile);

            if (user != null)
            {
                if (user.MobileActiveCode == activate.MobileActivationCode)
                {
                    user.IsMobileActive = true;
                    user.MobileActiveCode = new Random().Next(100000, 999999).ToString();
                    await _userRepository.SaveChanges();

                    return true;
                }
            }

            return false;
        }

        public async Task<bool> ChangeUserPassword(ChangePasswordDTO changePassword, long currentUserId)
        {
            var user = await _userRepository.GetEntityById(currentUserId);

            if (user != null)
            {
                var newPassword = _passwordHasher.EncodePasswordMd5(changePassword.NewPassword);

                if (newPassword != user.Password)
                {
                    user.Password = newPassword;
                    _userRepository.EditEntity(user);

                    await _userRepository.SaveChanges();
                    return true;
                }
            }
            return false;

        }

        public async Task<EditUserProfileDTO> GetProfileForEdit(long userId)
        {
            var user = await _userRepository.GetEntityById(userId);

            if (user == null)
            {
                return null;
            }

            return new EditUserProfileDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Avatar = user.Avatar
            };
        }

        public async Task<EditUserProfileResult> EditUserProfile(EditUserProfileDTO profile, long userId, IFormFile avatarImage)
        {

            var user = await _userRepository.GetEntityById(userId);

            if (user == null)
            {
                return EditUserProfileResult.NotFound;
            }
            if (user.IsBlocked)
            {
                return EditUserProfileResult.IsBlocked;
            }
            if (!user.IsMobileActive)
            {
                return EditUserProfileResult.IsNotActive;
            }

            user.FirstName = profile.FirstName;
            user.LastName = profile.LastName;

            if (avatarImage != null && avatarImage.IsImage())
            {
                var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(avatarImage.FileName);

                avatarImage.AddImageToServer(imageName, PathExtension.UserAvatarOriginServer,
                    100, 100, PathExtension.UserAvatarThumbServer, user.Avatar);

                user.Avatar = imageName;
            }

            _userRepository.EditEntity(user);
            await _userRepository.SaveChanges();

            return EditUserProfileResult.Success;
        }

        #endregion

        #region Dispose

        public async ValueTask DisposeAsync()
        {
            if (_userRepository != null)
            {
                await _userRepository.DisposeAsync();
            }
        }



        #endregion

    }
}
