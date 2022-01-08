using System;
using System.Collections.Generic;
using System.Linq;

namespace MarketPlace.DataLayer.DTOs.ProductOrder
{
    public class UserOpenOrderDTO
    {
        public long UserId { get; set; }
        public string Description { get; set; }
        public List<UserOpenOrderDetailItemDTO> Details { get; set; }

        public int GetTotalPriceWithoutDiscount()
        {
            return Details.Sum(x => (x.Count * (x.ProductPrice + x.ProductColorPrice)));
        }
        public int GetTotalDiscountPrice()
        {
            return Details.Sum(x => Convert.ToInt32((x.Count * x.DiscountPercentage * (x.ProductPrice + x.ProductColorPrice)) / 100));
        }
        public int GetTotalPriceWithDiscount()
        {
            return GetTotalPriceWithoutDiscount() - GetTotalDiscountPrice();
        }
       


    }

}
