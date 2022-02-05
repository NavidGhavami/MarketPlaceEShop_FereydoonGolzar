using System;
using System.Collections.Generic;

namespace MarketPlace.DataLayer.DTOs.Blog.Article
{
    public class ArticleDTO
    {
        #region Properties

        public long Id { get; set; }
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string MetaDescription { get; set; }
        public string CanonicalAddress { get; set; }
        public string PublishDate { get; set; }
        public List<string> KeywordList { get; set; }
        public List<Entities.Blog.Article> Articles { get; set; }
        public List<Entities.Blog.ArticleCategory> ArticleCategories { get; set; }

        #endregion
    }
}
