using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MarketPlace.Application.Extensions;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.Application.Utilities;
using MarketPlace.DataLayer.DTOs.Account;
using MarketPlace.DataLayer.DTOs.Paging;
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
        private readonly IGenericRepository<Role> _roleRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ISmsService _smsService;
        public UserService(IGenericRepository<User> userRepository, IPasswordHasher passwordHasher, ISmsService smsService, IGenericRepository<Role> roleRepository)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _smsService = smsService;
            _roleRepository = roleRepository;
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
                        EmailActiveCode = Guid.NewGuid().ToString("N"),
                        RoleId = 2,
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

        public async Task<User> GetUserById(long userId)
        {
            return await _userRepository.GetQuery().AsQueryable().SingleOrDefaultAsync(x => x.Id == userId);

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

        public async Task<FilterUserDTO> FilterUser(FilterUserDTO filter)
        {
            var query = _userRepository
                .GetQuery()
                .Include(x => x.Role)
                .AsQueryable();

            if (filter.RoleId > 0)
            {
                query = query.Where(x => x.RoleId == filter.RoleId);
            }
            if (!string.IsNullOrEmpty(filter.FirstName))
            {
                query = query.Where(x => EF.Functions.Like(x.FirstName, $"%{filter.FirstName}%"));
            }
            if (!string.IsNullOrEmpty(filter.LastName))
            {
                query = query.Where(x => EF.Functions.Like(x.LastName, $"%{filter.LastName}%"));
            }
            if (!string.IsNullOrEmpty(filter.Mobile))
            {
                query = query.Where(x => EF.Functions.Like(x.Mobile, $"%{filter.Mobile}%"));
            }
            if (!string.IsNullOrEmpty(filter.Email))
            {
                query = query.Where(x => EF.Functions.Like(x.Email, $"%{filter.Email}%"));
            }

            #region Paging


            var sellerCount = await query.CountAsync();

            var pager = Pager.Build(filter.PageId, sellerCount, filter.TakeEntity,
                filter.HowManyShowPageAfterAndBefore);

            var allEntities = await query.Paging(pager).ToListAsync();


            #endregion

            return filter.SetPaging(pager).SetUsers(allEntities);
        }

        public async Task<EditUserDTO> GetUserForEdit(long userId)
        {
            var user = await _userRepository.GetQuery()
                .AsQueryable()
                .Include(x => x.Role)
                .SingleOrDefaultAsync(x => x.Id == userId);

            if (user == null)
            {
                return null;
            }

            return new EditUserDTO
            {
                Id = user.Id,
                RoleId = user.Role.Id,
                Email = user.Email,
                Mobile = user.Mobile,
                IsBlocked = user.IsBlocked,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
        }

        public async Task<EditUserResult> EditUser(EditUserDTO edit)
        {
            var mainUser = await _userRepository
                .GetQuery()
                .AsQueryable()
                .Include(x=>x.Role)
                .SingleOrDefaultAsync(x => x.Id == edit.Id);

            if (mainUser == null)
            {
                return EditUserResult.UserNotFound;
            }

            mainUser.Id = edit.Id;
            mainUser.RoleId = edit.RoleId;
            mainUser.FirstName = edit.FirstName;
            mainUser.LastName = edit.LastName;
            mainUser.Mobile = edit.Mobile;
            mainUser.Email = edit.Email;
            mainUser.IsBlocked = edit.IsBlocked;

            _userRepository.EditEntity(mainUser);
            await _userRepository.SaveChanges();

            return EditUserResult.Success;
        }

        

        #endregion

        #region Role


        public async Task<FilterRoleDTO> FilterRole(FilterRoleDTO filter)
        {
            var query = _roleRepository
                .GetQuery()
                .Include(x => x.Users)
                .AsQueryable();

            if (!string.IsNullOrEmpty(filter.RoleName))
            {
                query = query.Where(x => EF.Functions.Like(x.RoleName, $"%{filter.RoleName}%"));
            }

            #region Paging

            var roleCount = await query.CountAsync();

            var pager = Pager.Build(filter.PageId, roleCount, filter.TakeEntity,
                filter.HowManyShowPageAfterAndBefore);

            var allEntities = await query.Paging(pager).ToListAsync();


            #endregion

            return filter.SetPaging(pager).SetRoles(allEntities);
        }

        public async Task<CreateRoleResult> CreateRole(CreateRoleDTO role)
        {
            var newRole = new Role
            {
                RoleName = role.RoleName,
            };

            await _roleRepository.AddEntity(newRole);
            await _roleRepository.SaveChanges();

            return CreateRoleResult.Success;
        }

        public async Task<EditRoleDTO> GetRoleForEdit(long roleId)
        {
            var role = await _roleRepository.GetEntityById(roleId);
            if (role == null)
            {
                return null;
            }

            return new EditRoleDTO
            {
                Id = role.Id,
                RoleName = role.RoleName
            };
        }

        public async Task<EditRoleResult> EditRole(EditRoleDTO edit)
        {
            var mainRole = await _roleRepository
                .GetQuery()
                .AsQueryable()
                .SingleOrDefaultAsync(x => x.Id == edit.Id);

            if (mainRole == null)
            {
                return EditRoleResult.Error;
            }

            mainRole.Id = edit.Id;
            mainRole.RoleName = edit.RoleName;

            _roleRepository.EditEntity(mainRole);
            await _roleRepository.SaveChanges();

            return EditRoleResult.Success;
        }

        public async Task<List<Role>> GetRoles()
        {
            return await _roleRepository
                .GetQuery()
                .AsQueryable()
                .Select(x=>new Role
                {
                    Id = x.Id,
                    RoleName = x.RoleName
                })
                .ToListAsync();

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
