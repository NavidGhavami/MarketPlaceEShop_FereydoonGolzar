using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.DataLayer.DTOs.Blog.Article;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Controllers
{
    public class BlogController : SiteBaseController
    {
        #region Constructor

        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        #endregion


        #region Filter Article

        [HttpGet("articles")]
        public async Task<IActionResult> ArticleList(FilterArticleDTO filter)
        {
            filter.TakeEntity = 12;

            var article = await _blogService.FilterArticle(filter);

            ViewBag.category = await _blogService.GetAllArticleCategories();

            return View(filter);
        }

        #endregion

        #region Article Details

        [HttpGet("article-detail/{articleId}/{title}")]
        public async Task<IActionResult> ArticleDetail(long articleId, string title)
        {
            var detail = await _blogService.GetArticleDetails(articleId);

            if (detail == null)
            {
                return RedirectToAction("PageNotFound", "Home");
            }

            return View(detail);
        }

        #endregion
    }
}
