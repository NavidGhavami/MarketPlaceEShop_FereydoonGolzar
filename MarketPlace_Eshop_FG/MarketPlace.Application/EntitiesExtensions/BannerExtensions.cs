using MarketPlace.Application.Utilities;
using MarketPlace.DataLayer.Entities.Site;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MarketPlace.Application.EntitiesExtensions
{
    public static class BannerExtensions
    {
        public static string GetBannerMainImageAddress(this SiteBanner banner)
        {
            return PathExtension.BannerOrigin + banner.ImageName;
        }
    }
}
