using System.ComponentModel.DataAnnotations;

namespace MarketPlace.DataLayer.DTOs.Site
{
    public class CaptchaViewModel
    {
        [Display(Name = "من ربات نیستم")]
        [Required(ErrorMessage = "لطفا تیک {0} را بزنید")]
        public string Captcha { get; set; }
    }
}
