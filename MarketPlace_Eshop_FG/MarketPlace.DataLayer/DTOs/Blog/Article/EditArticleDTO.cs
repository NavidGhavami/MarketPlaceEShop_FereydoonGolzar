namespace MarketPlace.DataLayer.DTOs.Blog.Article
{
    public class EditArticleDTO : CreateArticleDTO
    {
        public long Id { get; set; }
    }

    public enum EditArticleResult
    {
        Success,
        NotFound,
        Error
    }
}
