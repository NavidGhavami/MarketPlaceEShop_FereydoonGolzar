using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MarketPlace.Application.Extensions;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.Application.Utilities;
using MarketPlace.DataLayer.DTOs.Common;
using MarketPlace.DataLayer.DTOs.Paging;
using MarketPlace.DataLayer.DTOs.Seller;
using MarketPlace.DataLayer.Entities.Account;
using MarketPlace.DataLayer.Entities.Store;
using MarketPlace.DataLayer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Application.Services.Implementations
{
    public class SellerService : ISellerService
    {
        #region Constructor

        private readonly IGenericRepository<Seller> _sellerRepository;
        private readonly IGenericRepository<User> _userRepository;

        public SellerService(IGenericRepository<Seller> sellerRepository, IGenericRepository<User> userRepository)
        {
            _sellerRepository = sellerRepository;
            _userRepository = userRepository;
        }

        #endregion

        #region Seller

        public async Task<RequestSellerResult> AddNewSellerRequest(RequestSellerDTO seller, long userId, IFormFile logo, IFormFile nationalCard)
        {
            var user = await _userRepository.GetEntityById(userId);

            if (user.IsBlocked)
            {
                return RequestSellerResult.HasNotPermission;
            }

            var hasUnderProgressRequest = await _sellerRepository
                .GetQuery()
                .AsQueryable()
                .AnyAsync(x => x.UserId == userId && x.StoreAcceptanceState == StoreAcceptanceState.UnderProgress);

            if (hasUnderProgressRequest)
            {
                return RequestSellerResult.HasUnderProgressRequest;
            }

            if (logo != null && logo.IsImage())
            {
                var logoName = Guid.NewGuid().ToString("N") + Path.GetExtension(logo.FileName);
                logo.AddImageToServer(logoName, PathExtension.SellerLogoOriginServer, 80, 80, PathExtension.SellerLogoThumbServer, seller.Logo);
                seller.Logo = logoName;
            }

            if (nationalCard != null && nationalCard.IsImage())
            {
                var nationalCardName = Guid.NewGuid().ToString("N") + Path.GetExtension(nationalCard.FileName);
                nationalCard.AddImageToServer(nationalCardName, PathExtension.SellerNationalCardImageOriginServer, 120, 100, PathExtension.SellerNationalCardImageThumbServer, seller.NationalCardImage);
                seller.NationalCardImage = nationalCardName;
            }

            var newSeller = new Seller
            {
                UserId = userId,
                Phone = seller.Phone,
                Mobile = user.Mobile,
                Logo = seller.Logo,
                NationalCardImage = seller.NationalCardImage,
                Address = seller.Address,
                StoreName = seller.StoreName,
                NationalId = seller.NationalId,
                Description = seller.Description,
                StoreAcceptanceState = StoreAcceptanceState.UnderProgress,
            };

            await _sellerRepository.AddEntity(newSeller);
            await _sellerRepository.SaveChanges();

            return RequestSellerResult.Success;
        }

        public async Task<FilterSellerDTO> FilterSellers(FilterSellerDTO filter)
        {
            var query = _sellerRepository.GetQuery()
                .Include(x => x.User)
                .AsQueryable();

            #region State

            switch (filter.FilterSellerState)
            {
                case FilterSellerState.All:
                    query = query.Where(x => !x.IsDelete);
                    break;
                case FilterSellerState.UnderProgress:
                    query = query.Where(x => x.StoreAcceptanceState == StoreAcceptanceState.UnderProgress && !x.IsDelete);
                    break;
                case FilterSellerState.Accepted:
                    query = query.Where(x => x.StoreAcceptanceState == StoreAcceptanceState.Accepted && !x.IsDelete);
                    break;
                case FilterSellerState.Rejected:
                    query = query.Where(x => x.StoreAcceptanceState == StoreAcceptanceState.Rejected && !x.IsDelete);
                    break;
            }

            #endregion

            #region Filter

            if (filter.UserId != null && filter.UserId != 0)
            {
                query = query.Where(x => x.UserId == filter.UserId);
            }

            if (!string.IsNullOrEmpty(filter.StoreName))
            {
                query = query.Where(x => EF.Functions.Like(x.StoreName, $"%{filter.StoreName}%"));
            }
            if (!string.IsNullOrEmpty(filter.Phone))
            {
                query = query.Where(x => EF.Functions.Like(x.Phone, $"%{filter.Phone}%"));
            }
            if (!string.IsNullOrEmpty(filter.Mobile))
            {
                query = query.Where(x => EF.Functions.Like(x.Mobile, $"%{filter.Mobile}%"));
            }
            if (!string.IsNullOrEmpty(filter.NationalId))
            {
                query = query.Where(x => EF.Functions.Like(x.NationalId, $"%{filter.NationalId}%"));
            }
            if (!string.IsNullOrEmpty(filter.Address))
            {
                query = query.Where(x => EF.Functions.Like(x.Address, $"%{filter.Address}%"));
            }

            #endregion

            #region Paging


            var sellerCount = await query.CountAsync();

            var pager = Pager.Build(filter.PageId, sellerCount, filter.TakeEntity,
                filter.HowManyShowPageAfterAndBefore);

            var allEntities = await query.Paging(pager).ToListAsync();


            #endregion

            return filter.SetPaging(pager).SetSellers(allEntities);

        }

        public async Task<EditSellerRequestDTO> GetSellerRequestForEdit(long id, long currentUserId)
        {

            var seller = await _sellerRepository.GetEntityById(id);

            if (seller == null || seller.UserId != currentUserId)
            {
                return null;
            }

            return new EditSellerRequestDTO
            {
                Id = seller.Id,
                StoreName = seller.StoreName,
                Phone = seller.Phone,
                Mobile = seller.Mobile,
                Address = seller.Address,
                Description = seller.Description,
                AdminDescription = seller.AdminDescription,
                Logo = seller.Logo,
                NationalCardImage = seller.NationalCardImage,
                NationalId = seller.NationalId
            };
        }

        public async Task<EditSellerRequestResult> EditSellerRequest(EditSellerRequestDTO request, long currentUserId, IFormFile logo, IFormFile nationalCard)
        {
            var seller = await _sellerRepository.GetEntityById(request.Id);

            if (seller == null || seller.UserId != currentUserId)
            {
                return EditSellerRequestResult.NotFound;
            }

            if (logo != null && logo.IsImage())
            {
                var logoName = Guid.NewGuid().ToString("N") + Path.GetExtension(logo.FileName);
                logo.AddImageToServer(logoName, PathExtension.SellerLogoOriginServer, 80, 80, PathExtension.SellerLogoThumbServer, seller.Logo);
                request.Logo = logoName;
            }

            if (nationalCard != null && nationalCard.IsImage())
            {
                var nationalCardName = Guid.NewGuid().ToString("N") + Path.GetExtension(nationalCard.FileName);
                nationalCard.AddImageToServer(nationalCardName, PathExtension.SellerNationalCardImageOriginServer, 120, 100, PathExtension.SellerNationalCardImageThumbServer, seller.NationalCardImage);
                request.NationalCardImage = nationalCardName;
            }

            seller.StoreName = request.StoreName;
            seller.NationalId = request.NationalId;
            seller.Phone = request.Phone;
            seller.Mobile = request.Mobile;
            seller.Address = request.Address;
            seller.AdminDescription = request.AdminDescription;
            seller.Description = request.Description;
            seller.Logo = request.Logo;
            seller.NationalCardImage = request.NationalCardImage;
            seller.StoreAcceptanceState = StoreAcceptanceState.UnderProgress;

            _sellerRepository.EditEntity(seller);
            await _sellerRepository.SaveChanges();


            return EditSellerRequestResult.Success;

        }

        public async Task<bool> AcceptSellerRequest(long requestId)
        {
            var seller = await _sellerRepository.GetEntityById(requestId);

            if (seller != null)
            {
                seller.StoreAcceptanceState = StoreAcceptanceState.Accepted;
                seller.StoreAcceptanceDescription = "اطلاعات پنل فروشندگی شما، برای درخواست فروشندگی تایید شده است";
                seller.AdminDescription = "اطلاعات پنل فروشندگی شما، برای درخواست فروشندگی تایید شده است";

                _sellerRepository.EditEntity(seller);
                await _sellerRepository.SaveChanges();

                return true;
            }

            return false;
        }

        public async Task<bool> RejectSellerRequest(RejectItemDTO reject)
        {
            var seller = await _sellerRepository.GetEntityById(reject.Id);

            if (seller != null)
            {
                seller.StoreAcceptanceState = StoreAcceptanceState.Rejected;
                seller.StoreAcceptanceDescription = reject.RejectMessage;
                seller.AdminDescription = reject.RejectMessage;

                _sellerRepository.EditEntity(seller);
                await _sellerRepository.SaveChanges();


                return true;
            }

            return false;
        }

        public async Task<Seller> GetLastActiveSellerByUserId(long userId)
        {
            return await _sellerRepository
                .GetQuery()
                .AsQueryable()
                .OrderByDescending(x => x.CreateDate)
                .FirstOrDefaultAsync(x => x.UserId == userId && x.StoreAcceptanceState == StoreAcceptanceState.Accepted);
        }

        #endregion

        #region Dispose

        public async ValueTask DisposeAsync()
        {
            if (_sellerRepository != null)
            {
                await _sellerRepository.DisposeAsync();
            }
        }



        #endregion
    }
}
