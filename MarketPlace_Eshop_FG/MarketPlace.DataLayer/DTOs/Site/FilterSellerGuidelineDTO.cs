using System.Collections.Generic;
using MarketPlace.DataLayer.DTOs.Paging;
using MarketPlace.DataLayer.Entities.Site;

namespace MarketPlace.DataLayer.DTOs.Site
{
    public class FilterSellerGuidelineDTO : BasePaging
    {
        #region Properties

        public string QuestionTitle { get; set; }
        public string AnswerTitle { get; set; }
        public List<SellerGuideline> SellerGuidelines { get; set; }

        #endregion

        #region Methods

        public FilterSellerGuidelineDTO SetSellerGuideline(List<SellerGuideline> guideline)
        {
            this.SellerGuidelines = guideline;
            return this;
        }

        public FilterSellerGuidelineDTO SetPaging(BasePaging paging)
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
