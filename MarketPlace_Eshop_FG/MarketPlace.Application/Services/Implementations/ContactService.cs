using System.Linq;
using System.Threading.Tasks;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.Application.Utilities;
using MarketPlace.DataLayer.DTOs.Contact;
using MarketPlace.DataLayer.DTOs.Paging;
using MarketPlace.DataLayer.Entities.Contact;
using MarketPlace.DataLayer.Repository;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Application.Services.Implementations
{
    public class ContactService : IContactService
    {
        #region Constructor

        private readonly IGenericRepository<Ticket> _ticketRepository;
        private readonly IGenericRepository<TicketMessage> _ticketMessageRepository;

        public ContactService(IGenericRepository<Ticket> ticketRepository, IGenericRepository<TicketMessage> ticketMessageRepository)
        {
            _ticketRepository = ticketRepository;
            _ticketMessageRepository = ticketMessageRepository;
        }

        #endregion



        #region Ticket

        public async Task<AddTicketResult> AddUserTicket(AddTicketDTO ticket, long userId)
        {

            if (string.IsNullOrEmpty(ticket.Text))
            {
                return AddTicketResult.Error;
            }

            //Add Ticket
            var newTicket = new Ticket
            {
                OwnerId = userId,
                Title = ticket.Title,
                IsReadByOwner = true,
                TicketSection = ticket.TicketSection,
                TicketPriority = ticket.TicketPriority,
                TicketState = TicketState.UnderProgress,

            };

            await _ticketRepository.AddEntity(newTicket);
            await _ticketRepository.SaveChanges();


            //Add Message

            var newMessage = new TicketMessage
            {
                TicketId = newTicket.Id,
                SenderId = userId,
                Text = ticket.Text,

            };

            await _ticketMessageRepository.AddEntity(newMessage);
            await _ticketMessageRepository.SaveChanges();


            return AddTicketResult.Success;
        }

        public async Task<FilterTicketDTO> FilterTickets(FilterTicketDTO filter)
        {
            var query = _ticketRepository.GetQuery().AsQueryable();

            #region State

            switch (filter.FilterTicketState)
            {
                case FilterTicketState.All:
                    break;
                case FilterTicketState.Deleted:
                    query = query.Where(x => x.IsDelete);
                    break;
                case FilterTicketState.NotDeleted:
                    query = query.Where(x => !x.IsDelete);
                    break;
            }

            switch (filter.OrderBy)
            {
                case FilterTicketOrder.CreateDateAscending:
                    query = query.OrderBy(x => x.CreateDate);
                    break;
                case FilterTicketOrder.CreateDateDescending:
                    query = query.OrderByDescending(x => x.CreateDate);
                    break;
            }

            #endregion

            #region Filter

            if (filter.TicketSection != null)
            {
                query = query.Where(x => x.TicketSection == filter.TicketSection.Value);
            }
            if (filter.TicketPriority != null)
            {
                query = query.Where(x => x.TicketPriority == filter.TicketPriority.Value);
            }

            if (filter.UserId != null && filter.UserId != 0)
            {
                query = query.Where(x => x.OwnerId == filter.UserId.Value);
            }

            if (!string.IsNullOrEmpty(filter.Title))
            {
                query = query.Where(x => EF.Functions.Like(x.Title, $"%{filter.Title}%"));
            }

            #endregion

            #region Paging

            var ticketCount = await query.CountAsync();

            var pager = Pager.Build(filter.PageId, ticketCount, filter.TakeEntity,
                filter.HowManyShowPageAfterAndBefore);

            var allEntities = await query.Paging(pager).ToListAsync();

            #endregion

            return filter.SetPaging(pager).SetTickets(allEntities);
        }

        public async Task<TicketDetailDTO> GetTicketDetail(long ticketId, long userId)
        {
            var ticket = await _ticketRepository.GetQuery().AsQueryable()
                .Include(x => x.Owner)
                .OrderByDescending(x=>x.CreateDate)
                .SingleOrDefaultAsync(x => x.Id == ticketId);

            var ticketMessage = await _ticketMessageRepository.GetQuery().AsQueryable()
                .Where(x => x.TicketId == ticketId && !x.IsDelete)
                .OrderByDescending(x=>x.CreateDate)
                .ToListAsync();

            if (ticket == null || ticket.OwnerId != userId)
            {
                return null;
            }

            return new TicketDetailDTO
            {
                Ticket = ticket,
                TicketMessage = ticketMessage
            };
        }

        public async Task<AnswerTicketResult> AnswerTicket(AnswerTicketDTO answer, long userId)
        {
            var ticket = await _ticketRepository.GetEntityById(answer.Id);

            if (ticket == null)
            {
                return AnswerTicketResult.NotFound;
            }

            if (ticket.OwnerId != userId)
            {
                return AnswerTicketResult.NotForUser;
            }

            var ticketMessage = new TicketMessage
            {
                TicketId = ticket.Id,
                SenderId =  userId,
                Text = answer.Text
            };

            await _ticketMessageRepository.AddEntity(ticketMessage);
            await _ticketMessageRepository.SaveChanges();

            ticket.IsReadByAdmin = false;
            ticket.IsReadByOwner = true;

            await _ticketRepository.SaveChanges();

            return AnswerTicketResult.Success;
        }

        #endregion

        #region Dispose

        public async ValueTask DisposeAsync()
        {
            if (_ticketRepository != null)
            {
                await _ticketRepository.DisposeAsync();
            }

            if (_ticketMessageRepository != null)
            {
                await _ticketMessageRepository.DisposeAsync();
            }
        }

        #endregion

    }
}
