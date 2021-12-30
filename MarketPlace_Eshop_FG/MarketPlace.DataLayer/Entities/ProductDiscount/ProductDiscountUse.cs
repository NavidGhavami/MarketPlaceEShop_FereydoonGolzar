using MarketPlace.DataLayer.DTOs.Paging;
using MarketPlace.DataLayer.Entities.Account;
using MarketPlace.DataLayer.Entities.Common;

namespace MarketPlace.DataLayer.Entities.ProductDiscount
{
    public class ProductDiscountUse : BaseEntity
    {
        #region Properties

        public long ProductDiscountId { get; set; }
        public long UserId { get; set; }

        #endregion

        #region Relations

        public User User { get; set; }
        public ProductDiscount ProductDiscount { get; set; }

        #endregion
    }
}
