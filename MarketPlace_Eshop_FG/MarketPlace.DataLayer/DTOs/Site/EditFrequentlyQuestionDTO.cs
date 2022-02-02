namespace MarketPlace.DataLayer.DTOs.Site
{
    public class EditFrequentlyQuestionDTO : CreatefrequentlyQuestionDTO
    {
        public long Id { get; set; }
    }

    public enum EditFrequentlyQuestionResult
    {
        Success,
        NotFound, 
        Error
    }
}
