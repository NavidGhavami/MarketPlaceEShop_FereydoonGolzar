using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.DataLayer.DTOs.Wishlist;
using Microsoft.AspNetCore.Authorization;
using Nancy.Json;

namespace ServiceHost.Areas.User.Controllers
{
    public class HomeController : UserBaseController
    {
        #region Constructor

        private readonly IProductService _productService;
        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public const string CookieName = "wishlist-items";

        #endregion

        #region User Dashboard

        [HttpGet("dashboard")]
        public async Task<IActionResult> Dashboard()
        {
            return View();
        }

        #endregion

        #region WishList
        [AllowAnonymous]
        [HttpGet("wishlists")]
        public async Task<IActionResult> GetWishlist()
        {
            var serializer = new JavaScriptSerializer();
            var value = Request.Cookies[CookieName];

            var items = await _productService.GetProductWishlist();

            items = serializer.Deserialize<List<WishlistDTO>>(value);

            return View(items);
        }

        #endregion


        public IActionResult Index()
        {

            return View();
        }

    }

}

