using MarketPlace.Application.Utilities;
using MarketPlace.DataLayer.Entities.Site;

namespace MarketPlace.Application.EntitiesExtensions
{
    public static class SliderExtensions
    {
        public static string GetSliderImageAddress(this Slider slider)
        {
            return PathExtension.SliderOrigin + slider.ImageName;
        }
    }
}
