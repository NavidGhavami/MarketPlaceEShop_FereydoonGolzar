using System;
using System.Threading.Tasks;
using MarketPlace.DataLayer.DTOs.Common;
using MarketPlace.DataLayer.DTOs.Seller;
using MarketPlace.DataLayer.Entities.Store;
using Microsoft.AspNetCore.Http;

namespace MarketPlace.Application.Services.Interfaces
{
    public interface ISellerService : IAsyncDisposable
    {
        Task<RequestSellerResult> AddNewSellerRequest(RequestSellerDTO seller, long userId, IFormFile logo, IFormFile nationalCard);
        Task<FilterSellerDTO> FilterSellers(FilterSellerDTO filter);
        Task<EditSellerRequestDTO> GetSellerRequestForEdit(long id, long currentUserId);
        Task<EditSellerRequestResult> EditSellerRequest(EditSellerRequestDTO request, long currentUserId, IFormFile logo, IFormFile nationalCard);
        Task<bool> AcceptSellerRequest(long requestId);
        Task<bool> RejectSellerRequest(RejectItemDTO reject);
        Task<Seller> GetLastActiveSellerByUserId(long userId);
        Task<bool> HasUserAnyActiveSeller(long userId);
    }
}
