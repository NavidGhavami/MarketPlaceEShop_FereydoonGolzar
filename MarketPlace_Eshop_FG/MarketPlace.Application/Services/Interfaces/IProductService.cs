using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarketPlace.DataLayer.DTOs.Common;
using MarketPlace.DataLayer.DTOs.ProductComment;
using MarketPlace.DataLayer.DTOs.Products;
using MarketPlace.DataLayer.Entities.ProductDiscount;
using MarketPlace.DataLayer.Entities.Products;
using Microsoft.AspNetCore.Http;

namespace MarketPlace.Application.Services.Interfaces
{
    public interface IProductService : IAsyncDisposable
    {
        #region Products

        Task<FilterProductDTO> FilterProducts(FilterProductDTO filter);
        Task<FilterProductDTO> SearchProducts(FilterProductDTO filter);
        Task<FilterProductDTO> FilterProductsInAdmin(FilterProductDTO filter);
        Task<CreateProductResult> CreateProduct(CreateProductDTO product, long sellerId, IFormFile productImage);
        Task<bool> AcceptSellerProduct(long productId);
        Task<bool> RejectSellerProduct(RejectItemDTO reject);
        Task<EditProductDTO> GetProductForEdit(long productId);
        Task<EditProductResult> EditSellerProduct(EditProductDTO product, long userId, IFormFile productImage);
        Task RemoveAllProductSelectedCategories(long productId);
        Task RemoveAllProductColors(long productId);
        Task AddProductSelectedCategories(long productId, List<long> selectedCategories);
        Task AddProductColors(long productId, List<CreateProductColorDTO> colors);
        Task<ProductDetailsDTO> GetProductDetailsBy(long productId);
        Task<List<Product>> FilterProductForSellerByProductName(long sellerId, string productName);
        Task<List<ProductDiscount>> GetAllOffProducts(int take);
        Task<List<Product>> GetProductWithMaximumView(int take);
        Task<List<Product>> GetLatestArrivalProducts(int take);

        #endregion

        #region Product Category

        Task<List<ProductCategory>> GetAllProductCategoriesBy(long? parentId);
        Task<List<ProductCategory>> GetAllActiveProductCategories();
        Task<List<Product>> GetCategoryProductsByCategoryName(string categoryName, int take);
        Task<ProductCategory> GetProductCategoryByUrlName(string categoryUrlName);

        #endregion

        #region Product Gallery

        Task<List<ProductGallery>> GetAllProductGalleries(long productId);
        Task<List<ProductGallery>> GetAllProductGalleriesInSellerPanel(long productId, long sellerId);
        Task<Product> GetProductSellerOwnerBy(long productId, long userId);
        Task<CreateOrEditProductGalleryResult> CreateProductGallery(CreateOrEditProductGalleryDTO gallery, long productId, long sellerId);
        Task<CreateOrEditProductGalleryDTO> GetProductGalleryForEdit(long galleryId, long sellerId);
        Task<CreateOrEditProductGalleryResult> EditProductGallery(CreateOrEditProductGalleryDTO gallery, long galleryId, long sellerId);

        #endregion

        #region Product Feature

        Task RemoveAllProductFeatures(long productId);
        Task AddProductFeatures(long productId, List<CreateProductFeatureDTO> features);


        #endregion

        #region Product Comment

        Task<FilterProductCommentDTO> FilterProductsComment(FilterProductCommentDTO filter);
        Task<AddProductCommentResult> AddComment(AddProductCommentDTO comment, long productId, long userId);
        Task<bool> AcceptProductComment(long commentId);
        Task<bool> RejectProductComment(long commentId);

        #endregion
    }
}
