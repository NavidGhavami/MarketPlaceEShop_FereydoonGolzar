using System.IO;

namespace MarketPlace.Application.Utilities
{
    public static class PathExtension
    {
        #region Default Images

        public static string DefaultAvatar = "/Theme/assets/images/defaults/no-photo.png";


        #endregion

        #region Uploader

        public static string UploaderImage = "/Theme/assets/images/upload/";
        public static string UploaderImageServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Theme/assets/images/upload/");


        #endregion

        #region User Avatar

        public static string UserAvatarOrigin = "/Content/Images/UserAvatar/Origin/";
        public static string UserAvatarOriginServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Content/Images/UserAvatar/Origin/");

        public static string UserAvatarThumb = "/Content/Images/UserAvatar/Thumb/";
        public static string UserAvatarThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Content/Images/UserAvatar/Thumb/");

        #endregion

        #region Seller Logo and NationalCardImage

        public static string SellerLogoOrigin = "/Content/Images/SellerLogo/Origin/";
        public static string SellerLogoOriginServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Content/Images/SellerLogo/Origin/");

        public static string SellerLogoThumb = "/Content/Images/SellerLogo/Thumb/";
        public static string SellerLogoThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Content/Images/SellerLogo/Thumb/");

        public static string SellerNationalCardImageOrigin = "/Content/Images/SellerNationalCardImage/Origin/";
        public static string SellerNationalCardImageOriginServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Content/Images/SellerNationalCardImage/Origin/");

        public static string SellerNationalCardImageThumb = "/Content/Images/SellerNationalCardImage/Thumb/";
        public static string SellerNationalCardImageThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Content/Images/SellerNationalCardImage/Thumb/");

        #endregion

        #region Products

        public static string ProductOrigin = "/Content/Images/Product/Origin/";
        public static string ProductOriginServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Content/Images/Product/Origin/");

        public static string ProductThumb = "/Content/Images/Product/Thumb/";
        public static string ProductThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Content/Images/Product/Thumb/");

        #endregion

        #region Product Gallery

        public static string ProductGalleryOrigin = "/Content/Images/ProductGallery/Origin/";
        public static string ProductGalleryOriginServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Content/Images/ProductGallery/Origin/");

        public static string ProductGalleryThumb = "/Content/Images/ProductGallery/Thumb/";
        public static string ProductGalleryThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Content/Images/ProductGallery/Thumb/");

        #endregion

        #region Slider

        public static string SliderOrigin = "/Theme/assets/images/demos/demo-13/slider/";

        #endregion

        #region Banner

        public static string BannerOrigin = "/Theme/assets/images/demos/demo-13/banners/";

        #endregion
    }
}
