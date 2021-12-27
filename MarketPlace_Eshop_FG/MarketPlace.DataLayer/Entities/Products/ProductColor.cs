using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MarketPlace.DataLayer.Entities.Common;
using MarketPlace.DataLayer.Entities.ProductOrder;

namespace MarketPlace.DataLayer.Entities.Products
{
    public class ProductColor : BaseEntity
    {
        #region Properties

        public long ProductId { get; set; }

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

        #endregion

        #region Relations

        public Product Product { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }

        #endregion
    }
}
