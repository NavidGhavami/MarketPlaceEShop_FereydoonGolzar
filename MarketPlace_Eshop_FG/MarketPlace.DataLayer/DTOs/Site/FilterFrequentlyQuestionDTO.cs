using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MarketPlace.DataLayer.DTOs.Paging;
using MarketPlace.DataLayer.DTOs.Seller;
using MarketPlace.DataLayer.Entities.Site;

namespace MarketPlace.DataLayer.DTOs.Site
{
    public class FilterFrequentlyQuestionDTO : BasePaging
    {
        #region Properties

        public string QuestionHeader { get; set; }
        public string QuestionText { get; set; }
        public List<FrequentlyQuestion> FrequentlyQuestions { get; set; }

        #endregion





        #region Methods

        public FilterFrequentlyQuestionDTO SetFaq(List<FrequentlyQuestion> faq)
        {
            this.FrequentlyQuestions = faq;
            return this;
        }

        public FilterFrequentlyQuestionDTO SetPaging(BasePaging paging)
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
