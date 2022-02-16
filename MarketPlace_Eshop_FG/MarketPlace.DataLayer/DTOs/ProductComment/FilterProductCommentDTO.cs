using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MarketPlace.DataLayer.DTOs.Paging;

namespace MarketPlace.DataLayer.DTOs.ProductComment
{
    public class FilterProductCommentDTO : BasePaging
    {
        #region Constructor

        public FilterProductCommentDTO()
        {
            OrderBy = FilterProductCommentOrder.CreateDateDescending;
        }

        #endregion

        #region Properties

        public long ProductId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string CommentFeature { get; set; }
        public string CommentText { get; set; }
        public List<Entities.ProductComment.ProductComment> ProductComments { get; set; }
        public FilterProductCommentState ProductCommentState { get; set; }
        public FilterProductCommentOrder OrderBy { get; set; }


        #endregion

        #region Methods

        public FilterProductCommentDTO SetProductComment(List<Entities.ProductComment.ProductComment> productComments)
        {
            this.ProductComments = productComments;
            return this;
        }

        public FilterProductCommentDTO SetPaging(BasePaging paging)
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

    public enum FilterProductCommentState
    {
        [Display(Name = "همه")]
        All,

        [Display(Name = "درحال بررسی")]
        UnderProgress,

        [Display(Name = "تایید شده")]
        Accepted,

        [Display(Name = "رد شده")]
        Rejected,

    }

    public enum FilterProductCommentOrder
    {
        CreateDateDescending,
        CreateDateAscending,
    }

}

