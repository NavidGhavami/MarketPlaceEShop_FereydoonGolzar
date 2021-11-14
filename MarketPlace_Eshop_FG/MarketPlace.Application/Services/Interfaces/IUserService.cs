using System;
using System.Threading.Tasks;
using MarketPlace.DataLayer.DTOs.Account;

namespace MarketPlace.Application.Services.Interfaces
{
    public interface IUserService : IAsyncDisposable
    {
        #region Account

        Task<RegisterUserResult> RegisterUser(RegisterUserDTO register);
        Task<bool> IsUserExistsByMobileNumber(string mobile);

        #endregion
    }
}
