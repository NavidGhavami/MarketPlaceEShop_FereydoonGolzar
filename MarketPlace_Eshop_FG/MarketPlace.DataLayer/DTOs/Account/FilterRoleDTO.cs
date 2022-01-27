using System.Collections.Generic;
using MarketPlace.DataLayer.DTOs.Paging;
using MarketPlace.DataLayer.Entities.Account;

namespace MarketPlace.DataLayer.DTOs.Account
{
    public class FilterRoleDTO : BasePaging
    {
        public long Id { get; set; }
        public string RoleName { get; set; }
        public List<Role> Roles { get; set; }

        #region Methods

        public FilterRoleDTO SetRoles(List<Role> roles)
        {
            this.Roles = roles;
            return this;
        }

        public FilterRoleDTO SetPaging(BasePaging paging)
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
