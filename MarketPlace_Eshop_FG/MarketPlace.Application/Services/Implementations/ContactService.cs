using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MarketPlace.Application.Extensions;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.Application.Utilities;
using MarketPlace.DataLayer.DTOs.Contact;
using MarketPlace.DataLayer.DTOs.Paging;
using MarketPlace.DataLayer.Entities.Contact;
using MarketPlace.DataLayer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Application.Services.Implementations
{
    public class ContactService : IContactService
    {
        #region Constructor

        private readonly IGenericRepository<ContactUs> _contactUsRepository;
        private readonly IGenericRepository<AboutUs> _aboutUsRepository;

        private readonly IGenericRepository<Ticket> _ticketRepository;
        private readonly IGenericRepository<TicketMessage> _ticketMessageRepository;

        public ContactService(IGenericRepository<Ticket> ticketRepository, IGenericRepository<TicketMessage> ticketMessageRepository, IGenericRepository<ContactUs> contactUsRepository, IGenericRepository<AboutUs> aboutUsRepository)
        {
            _ticketRepository = ticketRepository;
            _ticketMessageRepository = ticketMessageRepository;
            _contactUsRepository = contactUsRepository;
            _aboutUsRepository = aboutUsRepository;
        }

        #endregion



        #region ContactUs

        public async Task<FilterContactUs> FilterContactUs(FilterContactUs filter)
        {
            var query = _contactUsRepository
                .GetQuery()
                .AsQueryable()
                .Include(x => x.User)
                .OrderByDescending(x => x.Id);

            #region Filter

            if (!string.IsNullOrEmpty(filter.Mobile))
            {
                query = query.Where(x => EF.Functions.Like(x.Mobile, $"%{filter.Mobile}%")).OrderByDescending(x => x.CreateDate);
            }


            #endregion

            #region Paging

            var contactCount = await query.CountAsync();

            var pager = Pager.Build(filter.PageId, contactCount, filter.TakeEntity,
                filter.HowManyShowPageAfterAndBefore);

            var allEntities = await query.Paging(pager).ToListAsync();

            #endregion

            return filter.SetPaging(pager).SetContactUs(allEntities);
        }

        public async Task CreateContactUs(CreateContactUsDTO contact, string userIp, long? userId)
        {
            var newContact = new ContactUs
            {
                UserId = (userId != null && userId.Value != 0) ? userId.Value : (long?)null,
                UserIp = userIp,
                Email = contact.Email,
                Mobile = contact.Mobile,
                Fullname = contact.Fullname,
                MessageText = contact.MessageText,
                MessageSubject = contact.MessageSubject,
            };

            await _contactUsRepository.AddEntity(newContact);
            await _contactUsRepository.SaveChanges();
        }

        public async Task<AboutUs> GetAboutUs()
        {
            return await _aboutUsRepository
                .GetQuery()
                .AsQueryable()
                .SingleOrDefaultAsync();
        }

        public async Task<CreateAboutUsResult> CreateAboutUs(CreateAboutUsDTO about, IFormFile aboutImage)
        {
            if (aboutImage != null && aboutImage.IsImage())
            {
                var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(aboutImage.FileName);
                aboutImage.AddImageToServer(imageName, PathExtension.AboutUsOriginServer,
                    100, 100, PathExtension.AboutUsThumbServer);

                var newAboutUs = new AboutUs
                {
                    AboutUsText = about.AboutUsText,
                    AboutUsImage = imageName,
                    Service1 = about.Service1,
                    Service2 = about.Service2,
                    Service3 = about.Service3,
                    Service4 = about.Service4,
                    Service5 = about.Service5,
                    Service6 = about.Service6,
                    ServiceSubject1 = about.ServiceSubject1,
                    ServiceSubject2 = about.ServiceSubject2,
                    ServiceSubject3 = about.ServiceSubject3,
                    ServiceSubject4 = about.ServiceSubject4,
                    ServiceSubject5 = about.ServiceSubject5,
                    ServiceSubject6 = about.ServiceSubject6,
                };

                await _aboutUsRepository.AddEntity(newAboutUs);
                await _aboutUsRepository.SaveChanges();

                return CreateAboutUsResult.Success;
            }

            return CreateAboutUsResult.Error;
        }

        public async Task<EditAboutUsDTO> GetAboutUsForEdit(long id)
        {
            var aboutUs = await _aboutUsRepository
                .GetQuery()
                .AsQueryable()
                .SingleOrDefaultAsync(x => x.Id == id);

            return new EditAboutUsDTO
            {
                AboutUsText = aboutUs.AboutUsText,
                AboutUsImage = aboutUs.AboutUsImage,
                Service1 = aboutUs.Service1,
                Service2 = aboutUs.Service2,
                Service3 = aboutUs.Service3,
                Service4 = aboutUs.Service4,
                Service5 = aboutUs.Service5,
                Service6 = aboutUs.Service6,
                ServiceSubject1 = aboutUs.ServiceSubject1,
                ServiceSubject2 = aboutUs.ServiceSubject2,
                ServiceSubject3 = aboutUs.ServiceSubject3,
                ServiceSubject4 = aboutUs.ServiceSubject4,
                ServiceSubject5 = aboutUs.ServiceSubject5,
                ServiceSubject6 = aboutUs.ServiceSubject6,
            };
        }

        public async Task<EditAboutUsResult> EditAboutUs(EditAboutUsDTO edit, IFormFile aboutImage)
        {
            var mainAbout = await _aboutUsRepository
                .GetQuery()
                .AsQueryable()
                .SingleOrDefaultAsync(x => x.Id == edit.Id);

            if (mainAbout == null)
            {
                return EditAboutUsResult.NotFound;
            }

            if (aboutImage != null && aboutImage.IsImage())
            {
                var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(aboutImage.FileName);
                aboutImage.AddImageToServer(imageName, PathExtension.AboutUsOriginServer,
                    100, 100, PathExtension.AboutUsThumbServer, mainAbout.AboutUsImage);

                mainAbout.AboutUsImage = imageName;
            }


            mainAbout.AboutUsText = edit.AboutUsText;
            mainAbout.Service1 = edit.Service1;
            mainAbout.Service2 = edit.Service2;
            mainAbout.Service3 = edit.Service3;
            mainAbout.Service4 = edit.Service4;
            mainAbout.Service5 = edit.Service5;
            mainAbout.Service6 = edit.Service6;
            mainAbout.ServiceSubject1 = edit.ServiceSubject1;
            mainAbout.ServiceSubject2 = edit.ServiceSubject2;
            mainAbout.ServiceSubject3 = edit.ServiceSubject3;
            mainAbout.ServiceSubject4 = edit.ServiceSubject4;
            mainAbout.ServiceSubject5 = edit.ServiceSubject5;
            mainAbout.ServiceSubject6 = edit.ServiceSubject6;

            _aboutUsRepository.EditEntity(mainAbout);
            await _aboutUsRepository.SaveChanges();

            return EditAboutUsResult.Success;
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
            var query = _ticketRepository
                .GetQuery()
                .Include(x => x.Owner)
                .AsQueryable();

            #region State

            switch (filter.FilterTicketState)
            {
                case FilterTicketState.All:
                    query = query.Where(x => !x.IsDelete);
                    break;
                case FilterTicketState.UnderProgress:
                    query = query.Where(x => !x.IsDelete && x.TicketState == TicketState.UnderProgress);
                    break;
                case FilterTicketState.Closed:
                    query = query.Where(x => !x.IsDelete && x.TicketState == TicketState.Closed);
                    break;
                case FilterTicketState.Answered:
                    query = query.Where(x => !x.IsDelete && x.TicketState == TicketState.Answered);
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
            if (filter.TicketState != null)
            {
                query = query.Where(x => x.TicketState == filter.TicketState.Value);
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
                .OrderByDescending(x => x.CreateDate)
                .SingleOrDefaultAsync(x => x.Id == ticketId);

            var ticketMessage = await _ticketMessageRepository.GetQuery().AsQueryable()
                .Where(x => x.TicketId == ticketId && !x.IsDelete)
                .OrderByDescending(x => x.CreateDate)
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
        public async Task<TicketDetailDTO> GetAdminTicketDetail(long ticketId, long userId)
        {
            var ticket = await _ticketRepository.GetQuery().AsQueryable()
                .Include(x => x.Owner)
                .OrderByDescending(x => x.CreateDate)
                .SingleOrDefaultAsync(x => x.Id == ticketId);

            var ticketMessage = await _ticketMessageRepository.GetQuery().AsQueryable()
                .Where(x => x.TicketId == ticketId && !x.IsDelete)
                .OrderByDescending(x => x.CreateDate)
                .ToListAsync();

            if (ticket == null)
            {
                return null;
            }

            ticket.Owner.Avatar ??= "no-photo.png";



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
                SenderId = userId,
                Text = answer.Text
            };

            await _ticketMessageRepository.AddEntity(ticketMessage);
            await _ticketMessageRepository.SaveChanges();

            ticket.IsReadByAdmin = false;
            ticket.IsReadByOwner = true;
            ticket.TicketState = TicketState.UnderProgress;

            await _ticketRepository.SaveChanges();

            return AnswerTicketResult.Success;
        }
        public async Task<AnswerTicketResult> AdminAnswerTicket(AnswerTicketDTO answer, long userId)
        {
            var ticket = await _ticketRepository.GetEntityById(answer.Id);

            if (ticket == null)
            {
                return AnswerTicketResult.NotFound;
            }


            var ticketMessage = new TicketMessage
            {
                TicketId = ticket.Id,
                SenderId = userId,
                Text = answer.Text
            };

            await _ticketMessageRepository.AddEntity(ticketMessage);
            await _ticketMessageRepository.SaveChanges();

            ticket.IsReadByAdmin = true;
            ticket.IsReadByOwner = false;
            ticket.TicketState = TicketState.Answered;

            await _ticketRepository.SaveChanges();

            return AnswerTicketResult.Success;
        }

        #endregion

        #region Dispose

        public async ValueTask DisposeAsync()
        {
            if (_contactUsRepository != null)
            {
                await _contactUsRepository.DisposeAsync();
            }
            if (_aboutUsRepository != null)
            {
                await _aboutUsRepository.DisposeAsync();
            }
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
