using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MarketPlace.DataLayer.DTOs.Products
{
    public class CreateProductDTO
    {
        [Display(Name = "نام محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Title { get; set; }

        [Display(Name = "قیمت محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Price { get; set; }

        [Display(Name = "توضیحات کوتاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string ShortDescription { get; set; }

        [Display(Name = "توضیحات اصلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Description { get; set; }

        [Display(Name = "فعال / غیرفعال")]
        public bool IsActive { get; set; }

        [Display(Name = "درصد سایت")]
        public int SiteProfit { get; set; }

        [Display(Name = "وزن محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int ProductWeight { get; set; }

        [Display(Name = "تعداد در انبار")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int StockCount { get; set; }

        [Display(Name = "موجود / ناموجود")]
        public bool InStock { get; set; }

        public List<CreateProductColorDTO> ProductColors { get; set; }
        public List<CreateProductFeatureDTO> ProductFeatures { get; set; }
        public List<long> SelectedCategories { get; set; }

    }

    public enum CreateProductResult
    {
        Success,
        Error,
        HasNoImage
    }
}
