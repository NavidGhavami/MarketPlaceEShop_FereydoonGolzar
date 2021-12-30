using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MarketPlace.DataLayer.Entities.Common;
using MarketPlace.DataLayer.Entities.Products;

namespace MarketPlace.DataLayer.Entities.ProductDiscount
{
    public class ProductDiscount : BaseEntity
    {
        #region Properties

        public long ProductId { get; set; }

        [Range(0,100)]
        public int Percentage { get; set; }

        public DateTime ExpireDate { get; set; }
        public int DiscountNumber { get; set; }


        #endregion

        #region Relations

        public Product Product { get; set; }
        public ICollection<ProductDiscountUse> ProductDiscountUse { get; set; }

        #endregion
    }
}
