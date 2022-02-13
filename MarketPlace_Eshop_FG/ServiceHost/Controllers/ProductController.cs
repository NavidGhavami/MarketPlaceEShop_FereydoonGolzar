﻿using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.DataLayer.DTOs.Products;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Controllers
{
    public class ProductController : SiteBaseController
    {
        #region Constructor

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        #endregion

        #region Filter Product

        [HttpGet("products")]
        [HttpGet("products/{Category}")]
        public async Task<IActionResult> FilterProducts(FilterProductDTO filter)
        {
            filter.TakeEntity = 12;
            filter = await _productService.FilterProducts(filter);
            ViewBag.ProductCategories = await _productService.GetAllActiveProductCategories();

            if (filter.PageId > filter.GetLastPage() && filter.GetLastPage() != 0)
            {
                return RedirectToAction("PageNotFound", "Home");
            }

            return View(filter);
        }

        #endregion

        #region Search Products

        [HttpGet("search-products")]
        [HttpGet("search-products/{Category}")]
        public async Task<IActionResult> SearchProducts(FilterProductDTO filter)
        {
            filter.TakeEntity = 12;
            filter = await _productService.SearchProducts(filter);
            ViewBag.ProductCategories = await _productService.GetAllActiveProductCategories();

            if (filter.PageId > filter.GetLastPage() && filter.GetLastPage() != 0)
            {
                return RedirectToAction("PageNotFound", "Home");
            }

            return View(filter);
        }

        #endregion


        #region Show Product Details

        [HttpGet("products/{productId}/{title}")]
        public async Task<IActionResult> ProductDetails(long productId , string title)
        {
            var product = await _productService.GetProductDetailsBy(productId);

            if (product == null)
            {
                return RedirectToAction("PageNotFound", "Home");
            }

            return View(product);
        }

        #endregion
    }
}
