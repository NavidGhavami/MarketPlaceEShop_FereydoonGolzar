using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace MarketPlace.DataLayer.DTOs.Products
{
    public class CreateOrEditProductGalleryDTO
    {
        [Display(Name = "الویت نمایش")]
        public int DisplayPriority { get; set; }

        [Display(Name = "تصویر گالری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public IFormFile Image { get; set; }

        public string ImageName { get; set; }
    }

    public enum CreateOrEditProductGalleryResult
    {
        Success,
        NotForUserProduct,
        ImageIsNull,
        ProductNotFound
    }
}
