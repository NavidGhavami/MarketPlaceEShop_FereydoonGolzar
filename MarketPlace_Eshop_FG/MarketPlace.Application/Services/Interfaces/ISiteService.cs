using System;
using System.Threading.Tasks;
using MarketPlace.DataLayer.Entities.Site;

namespace MarketPlace.Application.Services.Interfaces
{
    public interface ISiteService : IAsyncDisposable
    {
        #region Site Setting

        Task<SiteSetting> GetDefaultSiteSetting();

        #endregion
    }
}
