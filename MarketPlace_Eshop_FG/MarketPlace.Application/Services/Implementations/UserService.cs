using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.DataLayer.Entities.Account;
using MarketPlace.DataLayer.Repository;

namespace MarketPlace.Application.Services.Implementations
{
    public class UserService : IUserService
    {

        #region Constructor

        private readonly IGenericRepository<User> _userRepository;

        public UserService(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        #endregion


        #region Dispose

        public async ValueTask DisposeAsync()
        {
            await _userRepository.DisposeAsync();
        }

        #endregion
        
    }
}
