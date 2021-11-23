﻿namespace MarketPlace.DataLayer.DTOs.Paging
{
    public class BasePaging
    {
        public BasePaging()
        {
            PageId = 1;
            TakeEntity = 10;
            HowManyShowPageAfterAndBefore = 3;
        }

        public int PageId { get; set; }
        public int PageCount { get; set; }
        public int AllEntitesCount { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public int TakeEntity { get; set; }
        public int SkipEntity { get; set; }
        public int HowManyShowPageAfterAndBefore { get; set; }
    }
}
