﻿using System.ComponentModel.DataAnnotations;

namespace MarketPlace.DataLayer.DTOs.Products
{
    public class CreateProductFeatureDTO
    {
        public long ProductId { get; set; }

        [Display(Name = "عنوان ویژگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string FeatureTitle { get; set; }

        [Display(Name = "مقدار ویژگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string FeatureValue { get; set; }
    }
}
