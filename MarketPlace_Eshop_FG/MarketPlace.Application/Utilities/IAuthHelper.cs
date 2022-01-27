using System.Collections.Generic;
using System.Threading.Tasks;
using MarketPlace.DataLayer.DTOs.Account;

namespace MarketPlace.Application.Utilities
{
    public interface IAuthHelper
    {
        string CurrentAccountRole();
        AuthViewModel CurrentAccountInfo();
        long CurrentAccountId();
        Task<EditUserDTO> GetUserInfo(long id);
    }
}
