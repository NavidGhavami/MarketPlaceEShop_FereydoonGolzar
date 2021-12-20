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
        private readonly IGenericRepository<ProductGallery> _productGalleryRepository;
        private readonly IGenericRepository<ProductFeature> _productFeatureRepository;
        private readonly IGenericRepository<ProductCategory> _productCategoryRepository;
        private readonly IGenericRepository<ProductSelectedCategory> _productSelectedRepository;

        public ProductService(IGenericRepository<Product> productRepository, IGenericRepository<ProductCategory> productCategoryRepository,
            IGenericRepository<ProductSelectedCategory> productSelectedRepository, IGenericRepository<ProductColor> productColorRepository, 
            IGenericRepository<ProductGallery> productGalleryRepository, IGenericRepository<ProductFeature> productFeatureRepository)
        {
            _productRepository = productRepository;
            _productColorRepository = productColorRepository;
            _productGalleryRepository = productGalleryRepository;
            _productFeatureRepository = productFeatureRepository;
            _productCategoryRepository = productCategoryRepository;
            _productSelectedRepository = productSelectedRepository;
        }

        #endregion

        #region Products

        public async Task<FilterProductDTO> FilterProducts(FilterProductDTO filter)
        {
            var query = _productRepository
                .GetQuery()
                .Include(x => x.Seller)
                .ThenInclude(x => x.User)
                .Include(x => x.ProductSelectedCategories)
                .ThenInclude(x => x.ProductCategory)
                .Include(x => x.ProductColors)
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

            switch (filter.OrderBy)
            {
                case FilterProductOrderBy.CreateDateDescending:
                    query = query.OrderByDescending(x => x.CreateDate);
                    break;
                case FilterProductOrderBy.CreateDateAscending:
                    query = query.OrderBy(x => x.CreateDate);
                    break;
                case FilterProductOrderBy.PriceDescending:
                    query = query.OrderByDescending(x => x.Price);
                    break;
                case FilterProductOrderBy.PriceAscending:
                    query = query.OrderBy(x => x.Price);
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

            var expensiveProduct = await query.OrderByDescending(x => x.Price).FirstOrDefaultAsync();
            filter.FilterMaxPrice = expensiveProduct.Price;

            if (filter.SelectedMaxPrice == 0)
            {
                filter.SelectedMaxPrice = expensiveProduct.Price;
            }


            query = query.Where(x => x.Price >= filter.SelectedMinPrice && x.ProductAcceptanceState == ProductAcceptanceState.Accepted);
            query = query.Where(x => x.Price <= filter.SelectedMaxPrice && x.ProductAcceptanceState == ProductAcceptanceState.Accepted);

            if (!string.IsNullOrEmpty(filter.Category))
            {
                query = query.Where(x => x.ProductSelectedCategories.Any(s => s.ProductCategory.UrlName == filter.Category && x.ProductAcceptanceState == ProductAcceptanceState.Accepted));
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

        public async Task<FilterProductDTO> FilterProductsInAdmin(FilterProductDTO filter)
        {
            var query = _productRepository
                .GetQuery()
                .Include(x => x.ProductSelectedCategories)
                .ThenInclude(x => x.ProductCategory)
                .Include(x => x.Seller)
                .AsQueryable();

            #region State

            switch (filter.ProductState)
            {
                case FilterProductState.All:
                    query = query.Where(x => x.IsActive).OrderByDescending(x => x.CreateDate);
                    break;
                case FilterProductState.Active:
                    query = query.Where(x => x.IsActive && x.ProductAcceptanceState == ProductAcceptanceState.Accepted).OrderByDescending(x => x.CreateDate);
                    break;
                case FilterProductState.NotActive:
                    query = query.Where(x => !x.IsActive && x.ProductAcceptanceState == ProductAcceptanceState.Accepted).OrderByDescending(x => x.CreateDate);
                    break;
                case FilterProductState.Accepted:
                    query = query.Where(x => x.ProductAcceptanceState == ProductAcceptanceState.Accepted).OrderByDescending(x => x.CreateDate);
                    break;
                case FilterProductState.Rejected:
                    query = query.Where(x => x.ProductAcceptanceState == ProductAcceptanceState.Rejected).OrderByDescending(x => x.CreateDate);
                    break;
                case FilterProductState.UnderProgress:
                    query = query.Where(x => x.ProductAcceptanceState == ProductAcceptanceState.UnderProgress).OrderByDescending(x => x.CreateDate);
                    break;
            }

            #endregion

            #region Filter

            if (!string.IsNullOrEmpty(filter.ProductTitle))
            {
                query = query.Where(x => EF.Functions.Like(x.Title, $"%{filter.ProductTitle}%")).OrderByDescending(x => x.CreateDate);
            }

            if (filter.SellerId != null && filter.SellerId != 0)
            {
                query = query.Where(x => x.SellerId == filter.SellerId.Value).OrderByDescending(x => x.CreateDate);
            }

            if (!string.IsNullOrEmpty(filter.Category))
            {
                query = query.Where(x => x.ProductSelectedCategories.Any(s => s.ProductCategory.UrlName == filter.Category)).OrderByDescending(x => x.CreateDate);
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





                //create Product Category

                await AddProductSelectedCategories(newProduct.Id, product.SelectedCategories);
                await _productSelectedRepository.SaveChanges();

                //create Product Colors

                await AddProductColors(newProduct.Id, product.ProductColors);
                await _productColorRepository.SaveChanges();

                //create Product Features
                await AddProductFeatures(newProduct.Id, product.ProductFeatures);
                await _productFeatureRepository.SaveChanges();

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

        public async Task<EditProductDTO> GetProductForEdit(long productId)
        {
            var product = await _productRepository.GetEntityById(productId);

            var productColor = await _productColorRepository
                .GetQuery()
                .AsQueryable()
                .Where(x => x.ProductId == productId && !x.IsDelete)
                .Select(x => new CreateProductColorDTO
                {
                    Price = x.Price,
                    ColorName = x.ColorName,
                    ColorCode = x.ColorCode,
                })
                .ToListAsync();

            var selectedCategories = await _productSelectedRepository
                .GetQuery()
                .AsQueryable()
                .Where(x => x.ProductId == productId && !x.IsDelete)
                .Select(x => x.ProductCategoryId)
                .ToListAsync();

            var productFeature = await _productFeatureRepository
                .GetQuery()
                .AsQueryable()
                .Where(x => x.ProductId == productId && !x.IsDelete)
                .Select(x => new CreateProductFeatureDTO
                {
                    FeatureTitle = x.FeatureTitle,
                    FeatureValue = x.FeatureValue
                })
                .ToListAsync();


            if (product == null)
            {
                return null;
            }

            return new EditProductDTO
            {
                Id = productId,
                Title = product.Title,
                Price = product.Price,
                IsActive = product.IsActive,
                ProductColors = productColor,
                ProductImage = product.Image,
                ProductFeatures = productFeature,
                Description = product.Description,
                SelectedCategories = selectedCategories,
                ShortDescription = product.ShortDescription,
                ProductState = product.ProductAcceptanceState,
                ProductAcceptOrRejectDescription = product.ProductAcceptOrRejectDescription,

            };
        }

        public async Task<EditProductResult> EditSellerProduct(EditProductDTO product, long userId, IFormFile productImage)
        {
            var mainProduct = await _productRepository
                .GetQuery()
                .Include(x => x.Seller)
                .AsQueryable()
                .SingleOrDefaultAsync(x => x.Id == product.Id);


            if (mainProduct == null)
            {
                return EditProductResult.NotFound;
            }

            if (mainProduct.Seller.UserId != userId)
            {
                return EditProductResult.NotForUser;
            }

            mainProduct.Id = product.Id;
            mainProduct.Title = product.Title;
            mainProduct.Price = product.Price;
            mainProduct.IsActive = product.IsActive;
            mainProduct.Description = product.Description;
            mainProduct.ShortDescription = product.ShortDescription;
            mainProduct.ProductAcceptanceState = ProductAcceptanceState.UnderProgress;


            //Product Image

            if (productImage != null && productImage.IsImage())
            {
                var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(productImage.FileName);
                productImage.AddImageToServer(imageName, PathExtension.ProductOriginServer,
                    100, 100, PathExtension.ProductThumbServer, mainProduct.Image);

                mainProduct.Image = imageName;
            }

            //Remove All Product Categories
            await RemoveAllProductSelectedCategories(product.Id);
            // Add Product Categories
            await AddProductSelectedCategories(product.Id, product.SelectedCategories);
            await _productSelectedRepository.SaveChanges();
            //Remove Product Color
            await RemoveAllProductColors(product.Id);
            //Add Product Colors
            await AddProductColors(product.Id, product.ProductColors);
            await _productColorRepository.SaveChanges();
            //Remove Product Features
            await RemoveAllProductFeatures(product.Id);
            //AddProduct Features
            await AddProductFeatures(product.Id, product.ProductFeatures);
            

            return EditProductResult.Success;
        }


        public async Task<ProductDetailsDTO> GetProductDetailsBy(long productId)
        {
            var product = await _productRepository
                .GetQuery()
                .AsQueryable()
                .Include(x => x.Seller)
                .ThenInclude(x => x.User)
                .Include(x => x.ProductSelectedCategories)
                .ThenInclude(x => x.ProductCategory)
                .Include(x => x.ProductColors)
                .Include(x => x.ProductGalleries)
                .Include(x=>x.ProductFeatures)
                .SingleOrDefaultAsync(x => x.Id == productId);

            if (product == null)
            {
                return null;
            }

            var selectedCategoriesIds = product.ProductSelectedCategories.Select(x => x.ProductCategoryId).ToList();

            var relatedProducts = await _productRepository
                .GetQuery()
                .Include(x => x.ProductSelectedCategories)
                .ThenInclude(x=>x.ProductCategory)
                .Include(x=>x.ProductGalleries)
                .Include(x=>x.Seller)
                .ThenInclude(x=>x.User)
                .Where(x => x.ProductSelectedCategories.Any(c => selectedCategoriesIds.Contains(c.ProductCategoryId)) && x.Id != productId && x.ProductAcceptanceState == ProductAcceptanceState.Accepted)
                .ToListAsync();

            return new ProductDetailsDTO
            {

                Title = product.Title,
                Price = product.Price,
                Image = product.Image,
                SellerId = product.SellerId,
                Description = product.Description,
                ShortDescription = product.ShortDescription,
                Seller = product.Seller,
                ProductColors = product.ProductColors.ToList(),
                ProductFeatures = product.ProductFeatures.ToList(),
                ProductGalleries = product.ProductGalleries.ToList(),
                ProductCategories = product.ProductSelectedCategories.Select(x => x.ProductCategory).ToList(),
                RelatedProducts = relatedProducts

            };
        }

        #region Remove and Add ProductCategories, ProductColors, ProductFeatures

        public async Task RemoveAllProductSelectedCategories(long productId)
        {
            var productSelectedCategory = await _productSelectedRepository
                .GetQuery()
                .AsQueryable()
                .Where(x => x.ProductId == productId).ToListAsync();

            _productSelectedRepository.DeletePermanentEntities(productSelectedCategory);
        }
        public async Task RemoveAllProductColors(long productId)
        {
            var mainProductColor = await _productColorRepository
                .GetQuery()
                .AsQueryable()
                .Where(x => x.ProductId == productId).ToListAsync();

            _productColorRepository.DeletePermanentEntities(mainProductColor);
        }
        public async Task AddProductSelectedCategories(long productId, List<long> selectedCategories)
        {
            var productSelectedCategories = new List<ProductSelectedCategory>();

            foreach (var categoryId in selectedCategories)
            {
                productSelectedCategories.Add(new ProductSelectedCategory
                {
                    ProductCategoryId = categoryId,
                    ProductId = productId
                });
            }
            await _productSelectedRepository.AddRangeEntities(productSelectedCategories);
        }
        public async Task AddProductColors(long productId, List<CreateProductColorDTO> colors)
        {
            var productSelectedColors = new List<ProductColor>();

            foreach (var productColor in colors)
            {
                if (productSelectedColors.All(x => x.ColorName != productColor.ColorName))
                {
                    productSelectedColors.Add(new ProductColor
                    {
                        ProductId = productId,
                        ColorName = productColor.ColorName,
                        ColorCode = productColor.ColorCode,
                        Price = productColor.Price
                    });
                }
            }

            await _productColorRepository.AddRangeEntities(productSelectedColors);
        }



        #endregion

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

        #region Product Gallery

        public async Task<List<ProductGallery>> GetAllProductGalleries(long productId)
        {
            return await _productGalleryRepository
                .GetQuery()
                .AsQueryable()
                .Where(x => x.ProductId == productId)
                .ToListAsync();
        }

        public async Task<List<ProductGallery>> GetAllProductGalleriesInSellerPanel(long productId, long sellerId)
        {

            return await _productGalleryRepository
                .GetQuery()
                .Include(x => x.Product)
                .Where(x => x.ProductId == productId && x.Product.SellerId == sellerId)
                .ToListAsync();
        }

        public async Task<Product> GetProductSellerOwnerBy(long productId, long userId)
        {
            return await _productRepository
                .GetQuery()
                .Include(x => x.Seller)
                .AsQueryable()
                .SingleOrDefaultAsync(x => x.Id == productId && x.Seller.UserId == userId);
        }

        public async Task<CreateOrEditProductGalleryResult> CreateProductGallery(CreateOrEditProductGalleryDTO gallery, long productId, long sellerId)
        {
            var product = await _productRepository.GetEntityById(productId);

            if (product == null)
            {
                return CreateOrEditProductGalleryResult.ProductNotFound;
            }

            if (product.SellerId != sellerId)
            {
                return CreateOrEditProductGalleryResult.NotForUserProduct;
            }

            if (gallery.Image == null || !gallery.Image.IsImage())
            {
                return CreateOrEditProductGalleryResult.ImageIsNull;
            }

            var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(gallery.Image.FileName);
            gallery.Image.AddImageToServer(imageName, PathExtension.ProductGalleryOriginServer, 100, 100, PathExtension.ProductGalleryThumbServer);

            await _productGalleryRepository.AddEntity(new ProductGallery
            {
                ProductId = productId,
                ImageName = imageName,
                DisplayPriority = gallery.DisplayPriority
            });

            await _productGalleryRepository.SaveChanges();

            return CreateOrEditProductGalleryResult.Success;
        }

        public async Task<CreateOrEditProductGalleryDTO> GetProductGalleryForEdit(long galleryId, long sellerId)
        {
            var gallery = await _productGalleryRepository
                .GetQuery()
                .Include(x => x.Product)
                .SingleOrDefaultAsync(x => x.Id == galleryId && x.Product.SellerId == sellerId);

            if (gallery == null)
            {
                return null;
            }

            return new CreateOrEditProductGalleryDTO
            {
                ImageName = gallery.ImageName,
                DisplayPriority = gallery.DisplayPriority
            };
        }

        public async Task<CreateOrEditProductGalleryResult> EditProductGallery(CreateOrEditProductGalleryDTO gallery, long galleryId, long sellerId)
        {
            var mainGallery = await _productGalleryRepository
                .GetQuery()
                .Include(x => x.Product)
                .SingleOrDefaultAsync(x => x.Id == galleryId && x.Product.SellerId == sellerId);

            if (mainGallery == null)
            {
                return CreateOrEditProductGalleryResult.ProductNotFound;
            }

            if (mainGallery.Product.SellerId != sellerId)
            {
                return CreateOrEditProductGalleryResult.NotForUserProduct;
            }

            if (gallery.Image.IsImage() || gallery.Image != null)
            {

                var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(gallery.Image.FileName);
                gallery.Image.AddImageToServer(imageName, PathExtension.ProductGalleryOriginServer, 100, 100,
                        PathExtension.ProductGalleryThumbServer, mainGallery.ImageName);

                mainGallery.ImageName = imageName;

            }

            mainGallery.DisplayPriority = gallery.DisplayPriority;

            _productGalleryRepository.EditEntity(mainGallery);
            await _productGalleryRepository.SaveChanges();

            return CreateOrEditProductGalleryResult.Success;

        }



        #endregion

        #region Product Feature

        public async Task AddProductFeatures(long productId, List<CreateProductFeatureDTO> features)
        {
            var newFeatures = new List<ProductFeature>();
            if (features != null && features.Any())
            {
                foreach (var feature in features)
                {
                    newFeatures.Add(new ProductFeature()
                    {
                        ProductId = productId,
                        FeatureTitle = feature.FeatureTitle,
                        FeatureValue = feature.FeatureValue
                    });
                }

                await _productFeatureRepository.AddRangeEntities(newFeatures);
                await _productFeatureRepository.SaveChanges();
            }

        }

        public async Task RemoveAllProductFeatures(long productId)
        {
            var productFeatures = await _productFeatureRepository.GetQuery()
                .Where(s => s.ProductId == productId)
                .ToListAsync();

            _productFeatureRepository.DeletePermanentEntities(productFeatures);
            await _productFeatureRepository.SaveChanges();
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

            if (_productColorRepository != null)
            {
                await _productColorRepository.DisposeAsync();
            }
            if (_productFeatureRepository != null)
            {
                await _productFeatureRepository.DisposeAsync();
            }
            if (_productGalleryRepository != null)
            {
                await _productGalleryRepository.DisposeAsync();
            }
        }



        #endregion

    }
}
