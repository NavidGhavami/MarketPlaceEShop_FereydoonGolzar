using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MarketPlace.Application.Extensions;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.Application.Utilities;
using MarketPlace.DataLayer.DTOs.Common;
using MarketPlace.DataLayer.DTOs.Paging;
using MarketPlace.DataLayer.DTOs.Products;
using MarketPlace.DataLayer.Entities.Products;
using MarketPlace.DataLayer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Application.Services.Implementations
{
    public class ProductService : IProductService
    {
        #region Constructor

        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductColor> _productColorRepository;
        private readonly IGenericRepository<ProductCategory> _productCategoryRepository;
        private readonly IGenericRepository<ProductSelectedCategory> _productSelectedRepository;

        public ProductService(IGenericRepository<Product> productRepository, IGenericRepository<ProductCategory> productCategoryRepository,
            IGenericRepository<ProductSelectedCategory> productSelectedRepository, IGenericRepository<ProductColor> productColorRepository)
        {
            _productRepository = productRepository;
            _productColorRepository = productColorRepository;
            _productCategoryRepository = productCategoryRepository;
            _productSelectedRepository = productSelectedRepository;
        }

        #endregion

        #region Products

        public async Task<FilterProductDTO> FilterProducts(FilterProductDTO filter)
        {
            var query = _productRepository
                .GetQuery()
                .Include(x=>x.ProductSelectedCategories)
                .ThenInclude(x=>x.ProductCategory)
                .Include(x=>x.Seller)
                .AsQueryable();

            #region State

            switch (filter.ProductState)
            {
                case FilterProductState.All:
                    query = query.Where(x => x.IsActive);
                    break;
                case FilterProductState.Active:
                    query = query.Where(x => x.IsActive && x.ProductAcceptanceState == ProductAcceptanceState.Accepted);
                    break;
                case FilterProductState.NotActive:
                    query = query.Where(x => !x.IsActive && x.ProductAcceptanceState == ProductAcceptanceState.Accepted);
                    break;
                case FilterProductState.Accepted:
                    query = query.Where(x => x.ProductAcceptanceState == ProductAcceptanceState.Accepted);
                    break;
                case FilterProductState.Rejected:
                    query = query.Where(x => x.ProductAcceptanceState == ProductAcceptanceState.Rejected);
                    break;
                case FilterProductState.UnderProgress:
                    query = query.Where(x => x.ProductAcceptanceState == ProductAcceptanceState.UnderProgress);
                    break;
            }

            #endregion

            #region Filter

            if (!string.IsNullOrEmpty(filter.ProductTitle))
            {
                query = query.Where(x => EF.Functions.Like(x.Title, $"%{filter.ProductTitle}%"));
            }

            if (filter.SellerId != null && filter.SellerId != 0)
            {
                query = query.Where(x => x.SellerId == filter.SellerId.Value);
            }

            #endregion

            #region Paging

            var productCount = await query.CountAsync();

            var pager = Pager.Build(filter.PageId, productCount, filter.TakeEntity,
                filter.HowManyShowPageAfterAndBefore);

            var allEntities = await query.Paging(pager).ToListAsync();


            #endregion

            return filter.SetPaging(pager).SetProduct(allEntities);

        }

        public async Task<CreateProductResult> CreateProduct(CreateProductDTO product, long sellerId, IFormFile productImage)
        {
            if (productImage != null && productImage.IsImage())
            {
                var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(productImage.FileName);
                productImage.AddImageToServer(imageName, PathExtension.ProductOriginServer,
                    100, 100, PathExtension.ProductThumbServer);

                //create Product
                var newProduct = new Product
                {
                    SellerId = sellerId,
                    Title = product.Title,
                    Price = product.Price,
                    Image = imageName,
                    IsActive = product.IsActive,
                    Description = product.Description,
                    ShortDescription = product.ShortDescription,
                    ProductAcceptanceState = ProductAcceptanceState.UnderProgress

                };

                await _productRepository.AddEntity(newProduct);
                await _productRepository.SaveChanges();
            

           


            //create ProductCategory

            var productSelectedCategories = new List<ProductSelectedCategory>();

            foreach (var categoryId in product.SelectedCategories)
            {
                productSelectedCategories.Add(new ProductSelectedCategory
                {
                    ProductCategoryId = categoryId,
                    ProductId = newProduct.Id
                });
            }

            await _productSelectedRepository.AddRangeEntities(productSelectedCategories);
            await _productSelectedRepository.SaveChanges();

            //create Product Colors

            var productSelectedColors = new List<ProductColor>();

            foreach (var productColor in product.ProductColors)
            {
                productSelectedColors.Add(new ProductColor
                {
                    ProductId = newProduct.Id,
                    ColorName = productColor.ColorName,
                    Price = productColor.Price
                });
            }

            await _productColorRepository.AddRangeEntities(productSelectedColors);
            await _productColorRepository.SaveChanges();

            return CreateProductResult.Success;

            }

            return CreateProductResult.Error;
        }

        public async Task<bool> AcceptSellerProduct(long productId)
        {
            var product = await _productRepository.GetEntityById(productId);

            if (product != null)
            {
                product.ProductAcceptanceState = ProductAcceptanceState.Accepted;
                product.ProductAcceptOrRejectDescription = $"محصول مورد نظر در تاریخ {DateTime.Now.ToStringShamsiDate()}  مورد تایید سایت قرار گرفت";
                _productRepository.EditEntity(product);
                await _productRepository.SaveChanges();

                return true;
            }

            return false;
        }

        public async Task<bool> RejectSellerProduct(RejectItemDTO reject)
        {
            var product = await _productRepository.GetEntityById(reject.Id);

            if (product != null)
            {
                product.ProductAcceptanceState = ProductAcceptanceState.Rejected;
                product.ProductAcceptOrRejectDescription = reject.RejectMessage;

                _productRepository.EditEntity(product);
                await _productRepository.SaveChanges();

                return true;
            }

            return false;
        }

        #endregion

        #region Product Category

        public async Task<List<ProductCategory>> GetAllProductCategoriesBy(long? parentId)
        {
            if (parentId == null || parentId == 0)
            {
                return await _productCategoryRepository
                    .GetQuery()
                    .AsQueryable()
                    .Where(x => !x.IsDelete && x.IsActive && x.ParentId == null)
                    .ToListAsync();
            }

            return await _productCategoryRepository
                .GetQuery()
                .AsQueryable()
                .Where(x => !x.IsDelete && x.IsActive && x.ParentId == parentId)
                .ToListAsync();
        }

        public async Task<List<ProductCategory>> GetAllActiveProductCategories()
        {
            return await _productCategoryRepository
                .GetQuery()
                .AsQueryable()
                .Where(x => x.IsActive && !x.IsDelete)
                .ToListAsync();
        }

        #endregion



        #region Dispose
        public async ValueTask DisposeAsync()
        {
            if (_productRepository != null)
            {
                await _productRepository.DisposeAsync();
            }
            if (_productCategoryRepository != null)
            {
                await _productCategoryRepository.DisposeAsync();
            }
            if (_productSelectedRepository != null)
            {
                await _productSelectedRepository.DisposeAsync();
            }
        }



        #endregion

    }
}
