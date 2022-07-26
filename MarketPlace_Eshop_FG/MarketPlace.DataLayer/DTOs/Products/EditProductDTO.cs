using System.ComponentModel.DataAnnotations;
using MarketPlace.DataLayer.Entities.Products;

namespace MarketPlace.DataLayer.DTOs.Products
{
    public class EditProductDTO : CreateProductDTO
    {
        public long Id { get; set; }

        [Display(Name = "پیام تایید / عدم تایید محصول")]
        public string ProductAcceptOrRejectDescription { get; set; }

        [Display(Name = "تصویر محصول")]
        public string ProductImage { get; set; }

        public ProductAcceptanceState ProductState { get; set; }
    }

    public enum EditProductResult
    {
        NotFound,
        NotForUser,
        Success
    }
}
