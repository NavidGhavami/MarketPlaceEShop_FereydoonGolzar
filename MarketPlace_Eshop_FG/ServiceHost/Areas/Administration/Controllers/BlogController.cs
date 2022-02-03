using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.DataLayer.DTOs.Blog.Article;
using MarketPlace.DataLayer.DTOs.Blog.ArticleCategory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.Administration.Controllers
{
    public class BlogController : AdminBaseController
    {

        #region Constructor

        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        #endregion


        #region Article Category

        [HttpGet("article-category")]
        public async Task<IActionResult> ArticleCategoryList()
        {
            var articleCategory = await _blogService.GetAllArticleCategories();
            return View(articleCategory);
        }

        [HttpGet("create-article-category")]
        public async Task<IActionResult> CreateArticleCategory()
        {
            return View();
        }

        [HttpPost("create-article-category"), ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateArticleCategory(CreateArticleCategoryDTO articleCategory, IFormFile articleCategoryImage)
        {
            var result = await _blogService.CreateArticleCategory(articleCategory, articleCategoryImage);

            switch (result)
            {
                case CreateArticleCategoryResult.Error:
                    TempData[ErrorMessage] = "در افزودن اطلاعات خطایی رخ داد";
                    break;
                case CreateArticleCategoryResult.Success:
                    TempData[SuccessMessage] = "افزودن دسته مقاله با موفقیت انجام شد";
                    return RedirectToAction("ArticleCategoryList", "Blog");
            }

            return View();
        }

        [HttpGet("edit-article-category/{id}")]
        public async Task<IActionResult> EditArticleCategory(long id)
        {
            var articleCategory = await _blogService.GetArticleCategoryForEdit(id);
            return View(articleCategory);
        }

        [HttpPost("edit-article-category/{id}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> EditArticleCategory(EditArticleCategoryDTO edit, IFormFile articleCategoryImage)
        {
            var result = await _blogService.EditArticleCategory(edit, articleCategoryImage);

            switch (result)
            {
                case EditArticleCategoryResult.NotFound:
                    TempData[WarningMessage] = "اطلاعات مورد نظر یافت نشد";
                    break;
                case EditArticleCategoryResult.Success:
                    TempData[SuccessMessage] = "ویرایش اطلاعات دسته بندی مقاله با موفقیت انجام شد";
                    return RedirectToAction("ArticleCategoryList", "Blog");
            }

            return View();
        }

        #endregion

        #region Article

        [HttpGet("article-list")]
        public async Task<IActionResult> ArticleList(FilterArticleDTO filter)
        {
            var article = await _blogService.FilterArticle(filter);

            article.ArticleCategories = await _blogService.GetArticleCategoryList();
            ViewBag.Category = article.ArticleCategories;

            return View(filter);
        }

        [HttpGet("create-article")]
        public async Task<IActionResult> CreateArticle()
        {
            var articleCategory = await _blogService.GetArticleCategoryList();
            ViewBag.Category = articleCategory;

            return View();
        }

        [HttpPost("create-article"), ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateArticle(CreateArticleDTO article, IFormFile articleImage)
        {
            var result = await _blogService.CreateArticle(article, articleImage);

            switch (result)
            {
                case CreateArticleResult.Error:
                    TempData[ErrorMessage] = "در افزودن اطلاعات خطایی رخ داد";
                    break;
                case CreateArticleResult.Success:
                    TempData[SuccessMessage] = "افزودن مقاله با موفقیت انجام شد";
                    return RedirectToAction("ArticleList", "Blog");
            }

            ViewBag.Category = await _blogService.GetArticleCategoryList();
            return View();
        }


        [HttpGet("edit-article/{articleId}")]
        public async Task<IActionResult> EditArticle(long articleId)
        {
            var article = await _blogService.GetArticleForEdit(articleId);

            var articleCategory = await _blogService.GetArticleCategoryList();
            ViewBag.Category = articleCategory;

            return View(article);
        }

        [HttpPost("edit-article/{articleId}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> EditArticle(EditArticleDTO edit, IFormFile articleImage)
        {
            var result = await _blogService.EditArticle(edit, articleImage);

            switch (result)
            {
                case EditArticleResult.NotFound:
                    TempData[WarningMessage] = "اطلاعات مورد نظر یافت نشد";
                    break;
                case EditArticleResult.Success:
                    TempData[SuccessMessage] = "ویرایش مقاله با موفقیت انجام شد";
                    return RedirectToAction("ArticleList", "Blog");
            }

            ViewBag.Category = await _blogService.GetArticleCategoryList();
            return View();
        }

        #endregion
    }
}
