using System.Collections.Generic;
using MarketPlace.DataLayer.DTOs.Paging;
using MarketPlace.DataLayer.Entities.Site;

namespace MarketPlace.DataLayer.DTOs.Site
{
    public class FilterSiteGuidelineDTO : BasePaging
    {
        #region Properties

       
        public string Header { get; set; }
        public string Text { get; set; }
        public string Icon { get; set; }
        public List<SiteGuideline> SiteGuidelines { get; set; }

        #endregion

        #region Methods

        public FilterSiteGuidelineDTO SetSiteGuideline(List<SiteGuideline> guideline)
        {
            this.SiteGuidelines = guideline;
            return this;
        }

        public FilterSiteGuidelineDTO SetPaging(BasePaging paging)
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
