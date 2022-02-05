using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MarketPlace.Application.Extensions;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.Application.Utilities;
using MarketPlace.DataLayer.DTOs.Blog.Article;
using MarketPlace.DataLayer.DTOs.Blog.ArticleCategory;
using MarketPlace.DataLayer.DTOs.Paging;
using MarketPlace.DataLayer.Entities.Blog;
using MarketPlace.DataLayer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Application.Services.Implementations
{
    public class BlogService : IBlogService
    {

        #region Constructor

        private readonly IGenericRepository<ArticleCategory> _articleCategoryRepository;
        private readonly IGenericRepository<Article> _articleRepository;

        public BlogService(IGenericRepository<ArticleCategory> articleCategoryRepository, IGenericRepository<Article> articleRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _articleRepository = articleRepository;
        }

        #endregion


        #region Article Category

        public async Task<List<ArticleCategory>> GetAllArticleCategories()
        {
            var articleCategory = await _articleCategoryRepository
                .GetQuery()
                .Include(x=>x.Articles)
                .AsQueryable()
                .ToListAsync();

            return articleCategory;
        }

        public async Task<CreateArticleCategoryResult> CreateArticleCategory(CreateArticleCategoryDTO category, IFormFile articleCategoryImage)
        {
            if (articleCategoryImage != null && articleCategoryImage.IsImage())
            {
                var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(articleCategoryImage.FileName);
                articleCategoryImage.AddImageToServer(imageName, PathExtension.ArticleCategoryOriginServer,
                    100, 100, PathExtension.ArticleCategoryThumbServer);

                var newArticleCategory = new ArticleCategory
                {
                    Name = category.Name,
                    Image = imageName,
                    CanonicalAddress = category.CanonicalAddress,
                    Description = category.Description,
                    ShortDescription = category.ShortDescription,
                    Keywords = category.Keywords,
                    ShowOrder = Convert.ToInt32(category.ShowOrder),
                    MetaDescription = category.MetaDescription,
                };

                await _articleCategoryRepository.AddEntity(newArticleCategory);
                await _articleCategoryRepository.SaveChanges();

                return CreateArticleCategoryResult.Success;
            }

            return CreateArticleCategoryResult.Error;
        }

        public async Task<EditArticleCategoryDTO> GetArticleCategoryForEdit(long id)
        {
            var articleCategory = await _articleCategoryRepository
                .GetQuery()
                .AsQueryable()
                .SingleOrDefaultAsync(x => x.Id == id);

            return new EditArticleCategoryDTO
            {
                Id = articleCategory.Id,
                Name = articleCategory.Name,
                CanonicalAddress = articleCategory.CanonicalAddress,
                Description = articleCategory.Description,
                ShortDescription = articleCategory.ShortDescription,
                ShowOrder = Convert.ToString(articleCategory.ShowOrder),
                Keywords = articleCategory.Keywords,
                MetaDescription = articleCategory.MetaDescription,
                Image = articleCategory.Image,
            };
        }

        public async Task<EditArticleCategoryResult> EditArticleCategory(EditArticleCategoryDTO edit, IFormFile articleCategoryImage)
        {
            var mainCategory = await _articleCategoryRepository
                .GetQuery()
                .AsQueryable()
                .SingleOrDefaultAsync(x => x.Id == edit.Id);

            if (articleCategoryImage != null && articleCategoryImage.IsImage())
            {
                var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(articleCategoryImage.FileName);
                articleCategoryImage.AddImageToServer(imageName, PathExtension.ArticleCategoryOriginServer,
                    100, 100, PathExtension.ArticleCategoryThumbServer, mainCategory.Image);

                mainCategory.Image = imageName;
            }

            if (mainCategory == null)
            {
                return EditArticleCategoryResult.NotFound;
            }

            mainCategory.Name = edit.Name;
            mainCategory.CanonicalAddress = edit.CanonicalAddress;
            mainCategory.Description = edit.Description;
            mainCategory.ShortDescription = edit.ShortDescription;
            mainCategory.Keywords = edit.Keywords;
            mainCategory.ShowOrder = Convert.ToInt32(edit.ShowOrder);
            mainCategory.MetaDescription = edit.MetaDescription;

            _articleCategoryRepository.EditEntity(mainCategory);
            await _articleCategoryRepository.SaveChanges();

            return EditArticleCategoryResult.Success;

        }

        public async Task<List<ArticleCategory>> GetArticleCategoryList()
        {
            return await _articleCategoryRepository
                .GetQuery()
                .AsQueryable()
                .Select(x => new ArticleCategory
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();
        }

        #endregion

        #region Article

        public async Task<FilterArticleDTO> FilterArticle(FilterArticleDTO filter)
        {
            var query = _articleRepository
                .GetQuery()
                .Include(x => x.ArticleCategory)
                .AsQueryable();

            #region Filter

            if (filter.ArticleCategoryId != 0)
            {
                query = query.Where(x => x.ArticleCategoryId == filter.ArticleCategoryId);
            }

            if (!string.IsNullOrEmpty(filter.Title))
            {
                query = query.Where(x => EF.Functions.Like(x.Title, $"%{filter.Title}%"));
            }

            #endregion

            #region Paging


            var articleCount = await query.CountAsync();

            var pager = Pager.Build(filter.PageId, articleCount, filter.TakeEntity,
                filter.HowManyShowPageAfterAndBefore);

            var allEntities = await query.Paging(pager).OrderByDescending(x=>x.Id).ToListAsync();


            #endregion

            return filter.SetPaging(pager).SetArticle(allEntities);
        }

        public async Task<CreateArticleResult> CreateArticle(CreateArticleDTO article, IFormFile articleImage)
        {
            if (articleImage != null && articleImage.IsImage())
            {
                var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(articleImage.FileName);
                articleImage.AddImageToServer(imageName, PathExtension.ArticleOriginServer,
                    100, 100, PathExtension.ArticleThumbServer);

                var newArticle = new Article
                {
                    ArticleCategoryId = article.CategoryId,
                    Title = article.Title,
                    Image = imageName,
                    CanonicalAddress = article.CanonicalAddress,
                    Description = article.Description,
                    ShortDescription = article.ShortDescription,
                    Keywords = article.Keywords,
                    MetaDescription = article.MetaDescription,
                    PublishDate = article.PublishDate.ToMiladiDateTime(),
                };

                await _articleRepository.AddEntity(newArticle);
                await _articleRepository.SaveChanges();

                return CreateArticleResult.Success;
            }

            return CreateArticleResult.Error;
        }

        public async Task<EditArticleDTO> GetArticleForEdit(long id)
        {
            var article = await _articleRepository
                .GetQuery()
                .AsQueryable()
                .Include(x => x.ArticleCategory)
                .SingleOrDefaultAsync(x => x.Id == id);

            return new EditArticleDTO
            {
                Id = article.Id,
                CategoryId = article.ArticleCategoryId,
                Title = article.Title,
                CanonicalAddress = article.CanonicalAddress,
                Description = article.Description,
                ShortDescription = article.ShortDescription,
                Keywords = article.Keywords,
                MetaDescription = article.MetaDescription,
                Image = article.Image,
                PublishDate = article.PublishDate.ToShamsiDate()
            };
        }

        public async Task<EditArticleResult> EditArticle(EditArticleDTO edit, IFormFile articleImage)
        {
            var mainArticle = await _articleRepository
                .GetQuery()
                .AsQueryable()
                .SingleOrDefaultAsync(x => x.Id == edit.Id);

            if (articleImage != null && articleImage.IsImage())
            {
                var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(articleImage.FileName);
                articleImage.AddImageToServer(imageName, PathExtension.ArticleOriginServer,
                    100, 100, PathExtension.ArticleThumbServer, mainArticle.Image);

                mainArticle.Image = imageName;
            }

            if (mainArticle == null)
            {
                return EditArticleResult.NotFound;
            }

            mainArticle.Title = edit.Title;
            mainArticle.CanonicalAddress = edit.CanonicalAddress;
            mainArticle.Description = edit.Description;
            mainArticle.ShortDescription = edit.ShortDescription;
            mainArticle.Keywords = edit.Keywords;
            mainArticle.MetaDescription = edit.MetaDescription;
            mainArticle.PublishDate = edit.PublishDate.ToMiladiDateTime();

            _articleRepository.EditEntity(mainArticle);
            await _articleRepository.SaveChanges();

            return EditArticleResult.Success;
        }

        public async Task<List<ArticleDTO>> LatestArticles(int take = 10)
        {
            return await _articleRepository
                .GetQuery()
                .Include(x => x.ArticleCategory)
                .AsQueryable()
                .Where(x => !x.IsDelete && x.PublishDate <= DateTime.Now)
                .Take(take)
                .OrderByDescending(x=>x.Id)
                .Select(x => new ArticleDTO
                {
                    Id = x.Id,
                    CategoryId = x.ArticleCategoryId,
                    CategoryName = x.ArticleCategory.Name,
                    CanonicalAddress = x.CanonicalAddress,
                    Description = x.Description,
                    ShortDescription = x.ShortDescription,
                    Image = x.Image,
                    Keywords = x.Keywords,
                    MetaDescription = x.MetaDescription,
                    PublishDate = x.PublishDate.ToStringShamsiDate(),
                    Title = x.Title,

                }).ToListAsync();

        }

        public async Task<ArticleDTO> GetArticleDetails(long articleId)
        {
            var article = await _articleRepository
                .GetQuery()
                .Include(x => x.ArticleCategory)
                .AsQueryable()
                .SingleOrDefaultAsync(x => x.Id == articleId);

            if (article == null)
            {
                return new ArticleDTO();
            }

            var articleDetail = new ArticleDTO
            {
                Id = article.Id,
                Title = article.Title,
                CategoryId = article.ArticleCategoryId,
                CategoryName = article.ArticleCategory.Name,
                CanonicalAddress = article.CanonicalAddress,
                Description = article.Description,
                ShortDescription = article.ShortDescription,
                Image = article.Image,
                Keywords = article.Keywords,
                MetaDescription = article.MetaDescription,
                PublishDate = article.PublishDate.ToStringShamsiDate(),
                KeywordList = article.Keywords.Split(".").ToList()
            };


            return articleDetail;
        }

        #endregion


        #region Dispose

        public async ValueTask DisposeAsync()
        {
            if (_articleCategoryRepository != null)
            {
                await _articleCategoryRepository.DisposeAsync();
            }
            if (_articleRepository != null)
            {
                await _articleRepository.DisposeAsync();
            }
        }

        #endregion
    }
}
