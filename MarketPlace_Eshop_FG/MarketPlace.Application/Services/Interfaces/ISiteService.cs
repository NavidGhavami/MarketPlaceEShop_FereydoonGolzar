using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarketPlace.DataLayer.Entities.Site;

namespace MarketPlace.Application.Services.Interfaces
{
    public interface ISiteService : IAsyncDisposable
    {
        #region Site Setting

        Task<SiteSetting> GetDefaultSiteSetting();

        #endregion

        #region Slider

        Task<List<Slider>> GetAllActiveSlider();

        #endregion

        #region Site Banners

        Task<List<SiteBanner>> GetSiteBannersByLocations(List<SiteBanner.BannersLocations> locations);

        #endregion
    }
}
