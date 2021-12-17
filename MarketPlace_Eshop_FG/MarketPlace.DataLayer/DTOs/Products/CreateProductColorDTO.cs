using System.ComponentModel.DataAnnotations;

namespace MarketPlace.DataLayer.DTOs.Products
{
    public class CreateProductColorDTO
    {
        [Display(Name = "رنگ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string ColorName { get; set; }

        [Display(Name = "کد رنگ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string ColorCode { get; set; }

        [Display(Name = "قیمت")]
        public string Price { get; set; }
    }
}
