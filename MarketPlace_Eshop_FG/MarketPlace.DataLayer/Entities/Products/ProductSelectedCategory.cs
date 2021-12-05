using MarketPlace.DataLayer.Entities.Common;

namespace MarketPlace.DataLayer.Entities.Products
{
    public class ProductSelectedCategory : BaseEntity
    {
        #region Properties

        public long ProductId { get; set; }
        public long ProductCategoryId { get; set; }

        #endregion

        #region Relations

        public Product Product { get; set; }
        public ProductCategory ProductCategory { get; set; }
        #endregion
    }
}
