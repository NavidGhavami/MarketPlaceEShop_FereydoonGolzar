using System.IO;

namespace MarketPlace.Application.Utilities
{
    public static class PathExtension
    {
        #region Default Images

        public static string DefaultAvatar = "/Theme/assets/images/defaults/no-photo.png";


        #endregion

        #region User Avatar

        public static string UserAvatarOrigin = "/Content/Images/UserAvatar/Origin/";
        public static string UserAvatarOriginServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Content/Images/UserAvatar/Origin/");

        public static string UserAvatarThumb = "/Content/Images/UserAvatar/Thumb/";
        public static string UserAvatarThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Content/Images/UserAvatar/Thumb/");

        #endregion

        #region Slider

        public static string SliderOrigin = "/Theme/assets/images/demos/demo-13/slider/";

        #endregion

        #region Banner

        public static string BannerOrigin = "/Theme/assets/images/demos/demo-13/banners/";

        #endregion
    }
}
