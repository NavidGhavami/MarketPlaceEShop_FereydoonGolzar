using System.Collections.Generic;
using MarketPlace.DataLayer.Entities.Common;
using MarketPlace.DataLayer.Entities.ProductOrder;
using MarketPlace.DataLayer.Entities.Products;

namespace MarketPlace.DataLayer.Entities.Shipping
{
    public class Shipping : BaseEntity
    {
        #region Properties

        public long ProductId { get; set; }
        public string ShippingName { get; set; }
        public int BaseShippingPrice { get; set; }
        public int TotalShippingPrice { get; set; }
        

        #endregion

        #region Relation

        public Product Product { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }

        #endregion
    }
}
