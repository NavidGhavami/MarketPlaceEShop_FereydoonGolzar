using System;
using System.Collections.Generic;
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
        private readonly IGenericRepository<Slider> _sliderRepository;
        private readonly IGenericRepository<SiteBanner> _siteBanner;

        public SiteService(IGenericRepository<SiteSetting> siteSettingRepository, IGenericRepository<Slider> sliderRepository, IGenericRepository<SiteBanner> siteBanner)
        {
            _siteSettingRepository = siteSettingRepository;
            _sliderRepository = sliderRepository;
            _siteBanner = siteBanner;
        }

        #endregion


        #region Site Setting

        public async Task<SiteSetting> GetDefaultSiteSetting()
        {
            return await _siteSettingRepository.GetQuery().AsQueryable()
                .SingleOrDefaultAsync(x => x.IsDefault && !x.IsDelete);
        }



        #endregion

        #region Slider

        public async Task<List<Slider>> GetAllActiveSlider()
        {
            return await _sliderRepository.GetQuery().AsQueryable()
                .Where(x => x.IsActive && !x.IsDelete).ToListAsync();
        }

        #endregion

        #region Site Banners

        public async Task<List<SiteBanner>> GetSiteBannersByLocations(List<SiteBanner.BannersLocations> locations)
        {
            return await _siteBanner
                .GetQuery()
                .AsQueryable()
                .Where(x => locations.Contains(x.BannersLocation))
                .ToListAsync();
        }

        #endregion

        #region Dispose

        public async ValueTask DisposeAsync()
        {
            if (_siteSettingRepository != null)
            {
                await _siteSettingRepository.DisposeAsync();
            }
            if (_sliderRepository != null)
            {
                await _sliderRepository.DisposeAsync();
            }
            if (_sliderRepository != null)
            {
                await _siteBanner.DisposeAsync();
            }
        }


        #endregion

    }
}
