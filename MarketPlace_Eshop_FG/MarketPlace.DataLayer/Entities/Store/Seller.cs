using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MarketPlace.DataLayer.Entities.Account;
using MarketPlace.DataLayer.Entities.Common;
using MarketPlace.DataLayer.Entities.Wallet;

namespace MarketPlace.DataLayer.Entities.Store
{
    public class Seller : BaseEntity
    {
        #region Properties

        public long UserId { get; set; }

        [Display(Name = "نام فروشگاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string StoreName { get; set; }

        [Display(Name = "کد ملّی فروشنده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string NationalId { get; set; }

        [Display(Name = "تصویر کارت ملّی")]
        public string NationalCardImage { get; set; }

        [Display(Name = "تلفن ثابت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Phone { get; set; }

        [Display(Name = "تلفن همراه")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Mobile { get; set; }

        [Display(Name = "آدرس فروشگاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(650, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Address { get; set; }

        [Display(Name = "شماره حساب بانکی")]
        [MaxLength(250, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string BankAccountNumber { get; set; }

        [Display(Name = "شماره کارت بانکی")]
        [MaxLength(250, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string BankAccountCardNumber { get; set; }

        [Display(Name = "شماره شبا بانکی")]
        [MaxLength(250, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string BankAccountShabaNumber { get; set; }

        [Display(Name = "توضیحات فروشگاه")]
        public string Description { get; set; }

        [Display(Name = "یادداشت های ادمین")]
        public string AdminDescription { get; set; }

        [Display(Name = "توضیحات تایید / عدم تایید اطلاعات")]
        public string StoreAcceptanceDescription { get; set; }

        public StoreAcceptanceState StoreAcceptanceState { get; set; }

        #endregion

        #region Relations

        public User User { get; set; }
        public ICollection<SellerWallet> SellerWallets { get; set; }
        public ICollection<ChatRoom.ChatRoom> ChatRooms { get; set; }

        #endregion
    }

    public enum StoreAcceptanceState
    {
        [Display(Name = "درحال بررسی")]
        UnderProgress,

        [Display(Name = "تایید شده")]
        Accepted,

        [Display(Name = "رد شده")]
        Rejected
    }
}
