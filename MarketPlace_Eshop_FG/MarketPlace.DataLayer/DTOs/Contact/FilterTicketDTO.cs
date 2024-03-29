﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MarketPlace.DataLayer.DTOs.Paging;
using MarketPlace.DataLayer.Entities.Contact;

namespace MarketPlace.DataLayer.DTOs.Contact
{
    public class FilterTicketDTO : BasePaging
    {
        #region Properties

        public string Title { get; set; }
        public long? UserId { get; set; }
        public TicketSection? TicketSection { get; set; }
        public TicketPriority? TicketPriority { get; set; }
        public TicketState? TicketState { get; set; }
        public FilterTicketState FilterTicketState { get; set; }
        public FilterTicketOrder OrderBy { get; set; }
        public List<Ticket> Tickets { get; set; }


        #endregion

        #region Methods

        public FilterTicketDTO SetTickets(List<Ticket> tickets)
        {
            this.Tickets = tickets;
            return this;
        }

        public FilterTicketDTO SetPaging(BasePaging paging)
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

    public enum FilterTicketState
    {
        [Display(Name = "همه")]
        All,

        [Display(Name = "درحال بررسی")]
        UnderProgress,


        [Display(Name = "بسته شده")]
        Closed,

        [Display(Name = "پاسخ داده شده")]
        Answered,


    }

    public enum FilterTicketOrder
    {
        CreateDateDescending,
        CreateDateAscending,

    }
}
