using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarketPlace.DataLayer.DTOs.Blog.Article;
using MarketPlace.DataLayer.DTOs.Blog.ArticleCategory;
using MarketPlace.DataLayer.Entities.Blog;
using Microsoft.AspNetCore.Http;

namespace MarketPlace.Application.Services.Interfaces
{
    public interface IBlogService : IAsyncDisposable
    {
        #region Article Categories

        Task<List<ArticleCategory>> GetAllArticleCategories();
        Task<CreateArticleCategoryResult> CreateArticleCategory(CreateArticleCategoryDTO category, IFormFile articleCategoryImage);
        Task<EditArticleCategoryDTO> GetArticleCategoryForEdit(long id);
        Task<EditArticleCategoryResult> EditArticleCategory(EditArticleCategoryDTO edit, IFormFile articleCategoryImage);
        Task<List<ArticleCategory>> GetArticleCategoryList();

        #endregion

        #region Article

        Task<FilterArticleDTO> FilterArticle(FilterArticleDTO filter);
        Task<CreateArticleResult> CreateArticle(CreateArticleDTO article, IFormFile articleImage);
        Task<EditArticleDTO> GetArticleForEdit(long id);
        Task<EditArticleResult> EditArticle(EditArticleDTO edit, IFormFile articleImage);
        Task<List<ArticleDTO>> LatestArticles(int take = 10);
        Task<ArticleDTO> GetArticleDetails(long articleId);

        #endregion
    }
}
