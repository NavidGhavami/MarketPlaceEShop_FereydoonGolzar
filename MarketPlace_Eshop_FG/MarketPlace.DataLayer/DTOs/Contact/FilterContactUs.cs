using System.Collections.Generic;
using MarketPlace.DataLayer.DTOs.Paging;
using MarketPlace.DataLayer.Entities.Contact;

namespace MarketPlace.DataLayer.DTOs.Contact
{
    public class FilterContactUs : BasePaging
    {
        #region Properties

        public long? UserId { get; set; }
        public string UserIp { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string Mobile { get; set; }
        public string MessageSubject { get; set; }
        public string MessageText { get; set; }
        public List<ContactUs> ContactUs { get; set; }


        #endregion

        #region Methods

        public FilterContactUs SetContactUs(List<ContactUs> contact)
        {
            this.ContactUs = contact;
            return this;
        }

        public FilterContactUs SetPaging(BasePaging paging)
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
