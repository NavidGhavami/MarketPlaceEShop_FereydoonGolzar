namespace MarketPlace.DataLayer.DTOs.Blog.ArticleCategory
{
    public class EditArticleCategoryDTO : CreateArticleCategoryDTO
    {
        public long Id { get; set; }
    }

    public enum EditArticleCategoryResult
    {
        Success, 
        NotFound,
        Error
    }
}
