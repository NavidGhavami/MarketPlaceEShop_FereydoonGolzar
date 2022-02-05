using System;
using System.Collections.Generic;
using MarketPlace.DataLayer.DTOs.Paging;

namespace MarketPlace.DataLayer.DTOs.Blog.Article
{
    public class FilterArticleDTO : BasePaging
    {
        #region Properties

        public long ArticleCategoryId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string MetaDescription { get; set; }
        public string CanonicalAddress { get; set; }
        public DateTime PublishDate { get; set; }
        public string CategoryName { get; set; }
        public List<Entities.Blog.Article> Articles { get; set; }
        public List<Entities.Blog.ArticleCategory> ArticleCategories { get; set; }

        #endregion
        
        #region Methods

        public FilterArticleDTO SetArticle(List<Entities.Blog.Article> article)
        {
            this.Articles = article;
            return this;
        }

        public FilterArticleDTO SetPaging(BasePaging paging)
        {
            this.PageId = paging.PageId;
            this.AllEntitiesCount = paging.AllEntitiesCount;
            this.StartPage = paging.StartPage;
            this.EndPage = paging.EndPage;
            this.HowManyShowPageAfterAndBefore = paging.HowManyShowPageAfterAndBefore;
            this.TakeEntity = paging.TakeEntity;
            this.SkipEntity = paging.SkipEntity;
            this.PageCount = paging.PageCount;

            return this;
        }

        #endregion
    }
}
