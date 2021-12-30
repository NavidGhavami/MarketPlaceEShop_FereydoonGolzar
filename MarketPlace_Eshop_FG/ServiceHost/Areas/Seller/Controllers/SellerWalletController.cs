using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.DataLayer.DTOs.SellerWallet;
using Microsoft.AspNetCore.Mvc;
using ServiceHost.PresentationExtensions;

namespace ServiceHost.Areas.Seller.Controllers
{
    public class SellerWalletController : SellerBaseController
    {
        #region Constructor

        private readonly ISellerWalletService _sellerWalletService;
        private readonly ISellerService _sellerService;

        public SellerWalletController(ISellerWalletService sellerWalletService, ISellerService sellerService)
        {
            _sellerWalletService = sellerWalletService;
            _sellerService = sellerService;
        }

        #endregion


        #region Filter Seller Wallet

        [HttpGet("seller-wallet")]
        public async Task<IActionResult> Index(FilterSellerWalletDTO filter)
        {
            filter.TakeEntity = 5;

            var seller = await _sellerService.GetLastActiveSellerByUserId(User.GetUserId());

            if (seller == null)
            {
                return NotFound();
            }

            filter.SellerId = seller.Id;

            var filterSellerWallet = await _sellerWalletService.FilterSellerWallet(filter);
            return View(filterSellerWallet);
        }

        #endregion
        
    }
}
