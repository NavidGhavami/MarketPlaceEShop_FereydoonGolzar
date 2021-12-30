using System;
using MarketPlace.DataLayer.DTOs.ProductOrder;

namespace MarketPlace.Application.EntitiesExtensions
{
    public static class OrderExtensions
    {
        //public static int GetTotalPriceInCart(this UserOpenOrderDetailItemDTO detail)
        //{
        //    if (detail.DiscountPercentage != null)
        //    {
        //        return 
        //    }



        //}

        public static string GetTotalPriceWithDiscountForProduct(this UserOpenOrderDetailItemDTO detail)
        {
            if (detail.DiscountPercentage != null)
            {
                return Convert.ToInt32((detail.Count * (detail.ProductPrice + Convert.ToInt32(detail.ProductColorPrice))) -
                                       (Convert.ToInt32(detail.Count * detail.DiscountPercentage *
                                           (detail.ProductPrice + Convert.ToInt32(detail.ProductColorPrice)) / 100)))
                    .ToString("#,0");
            }

            return (detail.ProductPrice + Convert.ToInt32(detail.ProductColorPrice)).ToString("#,0");


        }

        public static string GetDiscountForProduct(this UserOpenOrderDetailItemDTO detail)
        {
            if (detail.DiscountPercentage != null)
            {
                return (Convert.ToInt32(detail.Count * detail.DiscountPercentage *
                    (detail.ProductPrice + Convert.ToInt32(detail.ProductColorPrice)) / 100)).ToString("#,0");
            }

            return "----";



        }
    }
}
