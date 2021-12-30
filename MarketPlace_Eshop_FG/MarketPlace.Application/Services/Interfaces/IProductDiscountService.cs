using System;
using System.Threading.Tasks;
using MarketPlace.DataLayer.DTOs.ProductDiscount;

namespace MarketPlace.Application.Services.Interfaces
{
    public interface IProductDiscountService : IAsyncDisposable
    {
        #region Product Discount

        Task<FilterProductDiscountDTO> FilterProductDiscount(FilterProductDiscountDTO filter);
        Task<CreateDiscountResult> CreateProductDiscount(CreateDiscountDTO discount, long sellerId);
        Task<EditDiscountDTO> GetDiscountForEdit(long discountId);
        Task<EditDiscountResult> EditProductDiscount(EditDiscountDTO discount, long sellerId);

        #endregion
    }
}
