using System;
using System.Linq;
using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.DataLayer.Entities.Site;
using MarketPlace.DataLayer.Repository;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Application.Services.Implementations
{
    public class SiteService : ISiteService
    {

        #region Constructor

        private readonly IGenericRepository<SiteSetting> _siteSettingRepository;

        public SiteService(IGenericRepository<SiteSetting> siteSettingRepository)
        {
            _siteSettingRepository = siteSettingRepository;
        }

        #endregion


        #region Site Setting

        public async Task<SiteSetting> GetDefaultSiteSetting()
        {
            return await _siteSettingRepository.GetQuery().AsQueryable()
                .SingleOrDefaultAsync(x => x.IsDefault && !x.IsDelete);
        }

        #endregion

        #region Dispose

        public async ValueTask DisposeAsync()
        {
            await _siteSettingRepository.DisposeAsync();
        }


        #endregion
    }
}
