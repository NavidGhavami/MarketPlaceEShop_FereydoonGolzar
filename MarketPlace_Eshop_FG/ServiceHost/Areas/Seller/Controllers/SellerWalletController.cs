using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.DataLayer.DTOs.SellerWallet;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.Seller.Controllers
{
    public class SellerWalletController : SellerBaseController
    {
        #region Constructor

        private readonly ISellerWalletService _sellerWalletService;

        public SellerWalletController(ISellerWalletService sellerWalletService)
        {
            _sellerWalletService = sellerWalletService;
        }

        #endregion


        #region Filter Seller Wallet

        [HttpGet("seller-wallet")]
        public async Task<IActionResult> Index(FilterSellerWalletDTO filter)
        {
            filter.TakeEntity = 5;
            
            var filterSellerWallet = await _sellerWalletService.FilterSellerWallet(filter);
            return View(filterSellerWallet);
        }

        #endregion
        
    }
}
