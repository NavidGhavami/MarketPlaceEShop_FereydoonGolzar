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
        Task<EditProductDTO> GetProductForEdit(long productId);
        Task<EditProductResult> EditSellerProduct(EditProductDTO product, long userId, IFormFile productImage);
        Task RemoveAllProductSelectedCategories(long productId);
        Task RemoveAllProductColors(long productId);
        Task AddProductSelectedCategories(long productId, List<long> selectedCategories);
        Task AddProductColors(long productId, List<CreateProductColorDTO> colors);

        #endregion

        #region Product Category

        Task<List<ProductCategory>> GetAllProductCategoriesBy(long? parentId);
        Task<List<ProductCategory>> GetAllActiveProductCategories();

        #endregion

        #region Product Gallery

        Task<List<ProductGallery>> GetAllProductGalleries(long productId);
        Task<List<ProductGallery>> GetAllProductGalleriesInSellerPanel(long productId, long sellerId);
        Task<Product> GetProductSellerOwnerBy(long productId, long userId);
        Task<CreateOrEditProductGalleryResult> CreateProductGallery(CreateOrEditProductGalleryDTO gallery, long productId, long sellerId);
        Task<CreateOrEditProductGalleryDTO> GetProductGalleryForEdit(long galleryId, long sellerId);
        Task<CreateOrEditProductGalleryResult> EditProductGallery(CreateOrEditProductGalleryDTO gallery, long galleryId, long sellerId);

        #endregion
    }
}
