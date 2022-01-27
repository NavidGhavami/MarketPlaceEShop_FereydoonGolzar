﻿using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.DataLayer.DTOs.Account;
using Microsoft.AspNetCore.Http;

namespace MarketPlace.Application.Utilities
{
    public class AuthHelper : IAuthHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUserService _userService;
        public AuthHelper(IHttpContextAccessor contextAccessor, IUserService userService)
        {
            _contextAccessor = contextAccessor;
            _userService = userService;
        }


        public bool IsAuthenticated()
        {

            return _contextAccessor.HttpContext.User.Identity != null && _contextAccessor.HttpContext.User.Identity.IsAuthenticated;

        }

        public string CurrentAccountRole()
        {
            return IsAuthenticated() ? _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value : null;
        }

        public AuthViewModel CurrentAccountInfo()
        {
            var result = new AuthViewModel();

            if (!IsAuthenticated())
            {
                return new AuthViewModel();
            }

            var claims = _contextAccessor.HttpContext.User.Claims.ToList();


            result.Id = long.Parse(claims.FirstOrDefault(x => x.Type == "Id")?.Value ?? throw new InvalidOperationException());
            result.FirstName = claims.FirstOrDefault(x => x.Type == "FirstName")?.Value;
            result.LastName = claims.FirstOrDefault(x => x.Type == "LastName")?.Value;
            result.RoleId = long.Parse(claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value ?? throw new InvalidOperationException());
            result.Username = claims.FirstOrDefault(x => x.Type == "Username")?.Value;
            result.Role = Roles.GetRoleBy(result.RoleId);
            result.Picture = claims.FirstOrDefault(x => x.Type == "Avatar")?.Value;
            result.Mobile = claims.FirstOrDefault(x => x.Type == "Mobile")?.Value;
            


            return result;

        }


        public long CurrentAccountId()
        {
            return IsAuthenticated() ? long.Parse(_contextAccessor.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == "UserId").Value) : 0;

        }

        public async Task<EditUserDTO> GetUserInfo(long id)
        {
            var user = await _userService.GetUserById(id);

            

            return new EditUserDTO
            {
                Id = user.Id,
                Image = user.Avatar,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
        }
    }
}