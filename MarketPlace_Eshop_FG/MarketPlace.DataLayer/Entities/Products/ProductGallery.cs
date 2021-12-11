using System.ComponentModel.DataAnnotations;
using MarketPlace.DataLayer.Entities.Common;

namespace MarketPlace.DataLayer.Entities.Products
{
    public class ProductGallery : BaseEntity
    {

        #region Properties

        public long ProductId { get; set; }

        [Display(Name = "اولویت نمایش")]
        public int DisplayPriority { get; set; }

        [Display(Name = "تصویر گالری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ImageName { get; set; }


        #endregion

        #region Relations

        public Product Product { get; set; }

        #endregion
    }
}
