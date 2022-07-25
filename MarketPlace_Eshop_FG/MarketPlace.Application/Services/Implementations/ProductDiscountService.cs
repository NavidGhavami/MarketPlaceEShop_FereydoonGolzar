using System.Linq;
using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.Application.Utilities;
using MarketPlace.DataLayer.DTOs.Paging;
using MarketPlace.DataLayer.DTOs.ProductDiscount;
using MarketPlace.DataLayer.Entities.ProductDiscount;
using MarketPlace.DataLayer.Entities.Products;
using MarketPlace.DataLayer.Repository;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Application.Services.Implementations
{
    public class ProductDiscountService : IProductDiscountService
    {
        #region Constructor

        private readonly IGenericRepository<ProductDiscount> _productDiscountRepository;
        private readonly IGenericRepository<ProductDiscountUse> _productDiscountUseRepository;
        private readonly IGenericRepository<Product> _productRepository;

        public ProductDiscountService(IGenericRepository<ProductDiscount> productDiscountRepository, IGenericRepository<ProductDiscountUse> productDiscountUseRepository, IGenericRepository<Product> productRepository)
        {
            _productDiscountRepository = productDiscountRepository;
            _productDiscountUseRepository = productDiscountUseRepository;
            _productRepository = productRepository;
        }

        #endregion

        #region Product Discount

        public async Task<FilterProductDiscountDTO> FilterProductDiscount(FilterProductDiscountDTO filter)
        {
            var query = _productDiscountRepository
                .GetQuery()
                .Include(x => x.Product)
                .AsQueryable();

            #region Filter

            if (filter.ProductId != null && filter.ProductId != 0)
            {
                query = query.Where(x => x.ProductId == filter.ProductId.Value);
            }

            if (filter.SellerId != null && filter.SellerId != 0)
            {
                query = query.Where(x => x.Product.SellerId == filter.SellerId.Value);
            }

            #endregion

            #region Paging

            var productDiscountCount = await query.CountAsync();

            var pager = Pager.Build(filter.PageId, productDiscountCount, filter.TakeEntity,
                filter.HowManyShowPageAfterAndBefore);

            var allEntities = await query.Paging(pager).ToListAsync();

            #endregion


            return filter.SetPaging(pager).SetProductDiscount(allEntities);
        }

        public async Task<CreateDiscountResult> CreateProductDiscount(CreateDiscountDTO discount, long sellerId)
        {
            var product = await _productRepository.GetEntityById(discount.ProductId);

            if (product == null)
            {
                return CreateDiscountResult.ProductNotFound;
            }

            if (product.SellerId != sellerId)
            {
                return CreateDiscountResult.ProductIsNotForSeller;
            }

            var newDiscount = new ProductDiscount
            {
                ProductId = product.Id,
                DiscountNumber = discount.DiscountNumber,
                Percentage = discount.Percentage,
                ExpireDate = discount.ExpireDate.ToMiladiDateTime()
            };

            await _productDiscountRepository.AddEntity(newDiscount);
            await _productDiscountRepository.SaveChanges();

            return CreateDiscountResult.Success;

        }

        public async Task<EditDiscountDTO> GetDiscountForEdit(long discountId)
        {

            var discount = await _productDiscountRepository
                .GetQuery()
                .Include(x => x.Product)
                .SingleOrDefaultAsync(x => x.Id == discountId);


            if (discount == null)
            {
                return null;
            }



            return new EditDiscountDTO
            {
                Id = discountId,
                ProductId = discount.ProductId,
                DiscountNumber = discount.DiscountNumber,
                Percentage = discount.Percentage,
                ExpireDate = discount.ExpireDate.ToShamsiDate(),
                ProductTitle = discount.Product.Title
            };
        }

        public async Task<EditDiscountResult> EditProductDiscount(EditDiscountDTO discount, long sellerId)
        {
            var mainDiscount = await _productDiscountRepository
                .GetQuery()
                .Include(x => x.Product)
                .AsQueryable()
                .SingleOrDefaultAsync(x => x.Id == discount.Id);

            var product = await _productRepository.GetEntityById(discount.ProductId);

            if (product == null)
            {
                return EditDiscountResult.ProductNotFound;
            }

            if (product.SellerId != sellerId)
            {
                return EditDiscountResult.ProductIsNotForSeller;
            }

            mainDiscount.Id = discount.Id;
            mainDiscount.ProductId = product.Id;
            mainDiscount.DiscountNumber = discount.DiscountNumber;
            mainDiscount.Percentage = discount.Percentage;
            mainDiscount.ExpireDate = discount.ExpireDate.ToMiladiDateTime();


            await _productDiscountRepository.SaveChanges();

            return EditDiscountResult.Success;
        }

        #endregion



        #region Dispose

        public async ValueTask DisposeAsync()
        {
            if (_productDiscountRepository != null)
            {
                await _productDiscountRepository.DisposeAsync();
            }
            if (_productDiscountUseRepository != null)
            {
                await _productDiscountUseRepository.DisposeAsync();
            }
        }

        #endregion
    }
}
