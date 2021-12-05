using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarketPlace.DataLayer.DTOs.Common;
using MarketPlace.DataLayer.DTOs.Products;
using MarketPlace.DataLayer.Entities.Products;
using Microsoft.AspNetCore.Http;

namespace MarketPlace.Application.Services.Interfaces
{
    public interface IProductService : IAsyncDisposable
    {
        #region Products

        Task<FilterProductDTO> FilterProducts(FilterProductDTO filter);
        Task<CreateProductResult> CreateProduct(CreateProductDTO product, long sellerId, IFormFile productImage);
        Task<bool> AcceptSellerProduct(long productId);
        Task<bool> RejectSellerProduct(RejectItemDTO reject);

        #endregion

        #region Product Category

        Task<List<ProductCategory>> GetAllProductCategoriesBy(long? parentId);
        Task<List<ProductCategory>> GetAllActiveProductCategories();

        #endregion
    }
}
