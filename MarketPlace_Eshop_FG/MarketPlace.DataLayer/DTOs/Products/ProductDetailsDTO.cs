﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MarketPlace.DataLayer.Entities.Products;

namespace MarketPlace.DataLayer.DTOs.Products
{
    public class ProductDetailsDTO
    {

        public long ProductId { get; set; }

        public long SellerId { get; set; }

        [Display(Name = "نام محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Title { get; set; }

        [Display(Name = "تصویر محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Image { get; set; }

        [Display(Name = "قیمت محصول")]
        public int Price { get; set; }

        [Display(Name = "توضیحات کوتاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string ShortDescription { get; set; }

        [Display(Name = "توضیحات اصلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Description { get; set; }

        [Display(Name = "تعداد بازدید")]
        public int View { get; set; }

        public Entities.Store.Seller Seller { get; set; }
        public List<ProductGallery> ProductGalleries { get; set; }
        public List<ProductColor> ProductColors { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
        public List<ProductFeature> ProductFeatures { get; set; }
        public List<Product> RelatedProducts { get; set; }
        public List<Entities.ProductComment.ProductComment> ProductComments { get; set; }
        public Entities.ProductDiscount.ProductDiscount ProductDiscount { get; set; }
    }
}
