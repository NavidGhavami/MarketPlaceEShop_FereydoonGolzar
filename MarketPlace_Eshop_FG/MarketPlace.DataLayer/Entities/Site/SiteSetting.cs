﻿using System.ComponentModel.DataAnnotations;
using MarketPlace.DataLayer.Entities.Common;

namespace MarketPlace.DataLayer.Entities.Site
{
    public class SiteSetting : BaseEntity
    {
        #region Properties

        [Display(Name = "تلفن همراه")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Mobile { get; set; }

        [Display(Name = "تلفن")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Phone { get; set; }

        [Display(Name = "آدرس ایمیل")]
        [EmailAddress(ErrorMessage = "فرمت ایمیل صحیح نمی باشد")]
        [MaxLength(250, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Email { get; set; }

        [Display(Name = " متن کپی رایت")]
        public string CopyRight { get; set; }

        [Display(Name = "متن فوتر")]
        public string FooterText { get; set; }

        [Display(Name = "آدرس نقشه")]
        public string MapScript { get; set; }

        [Display(Name = "آدرس")]
        public string Address { get; set; }

        [Display(Name = "اصلی هست / نیست")]
        public bool IsDefault { get; set; }

        #endregion
    }
}
