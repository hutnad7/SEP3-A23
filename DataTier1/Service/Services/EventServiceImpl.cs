using Data.Interfaces;
using Data.Models;
using Data.Repositories;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.VisualBasic;
using MySqlX.XDevAPI.Common;
using System.Globalization;
using System.Runtime.Serialization;
using System.Xml.Linq;
using static Org.BouncyCastle.Bcpg.Attr.ImageAttrib;

namespace Service.Services
{
    public class EventServiceImpl : EventService.EventServiceBase
    {
        private readonly ILogger<EventServiceImpl> _logger;
        private readonly IEventRepository _eventRepository;
        private readonly IBookingRepository _bookingRepository;
        public EventServiceImpl(ILogger<EventServiceImpl> logger, IEventRepository eventRepository, IBookingRepository bookingRepository)
        {
            _logger = logger;
            _eventRepository = eventRepository;
            _bookingRepository = bookingRepository;
        }
        public override async Task<GetEventsResponse> GetAllEvents(Empty request, ServerCallContext context)
        {
            ICollection<Event> events = await _eventRepository.GetAll();
            ICollection<GetEventResponse> e = new List<GetEventResponse>();
            foreach (Event ev in events)
            {
                GetEventResponse response = new GetEventResponse()
                {
                    Id = ev.Id.ToString(),
                    Name = ev.Title.ToString(),
                    Description = ev.Text.ToString(),
                    CafeOwner = ev.CafeOwner.Username.ToString(),
                    Entertainer = ev.Enterteiner.Username.ToString(),
                    StartDate = ev.StartDate.ToString(),
                    EndDate = ev.EndDate.ToString(),
                    AvailablePlaces = ev.AvailablePlaces,
                    State = ev.state.ToString(),
                    CafeOwnerId = ev.CafeOwnerId.ToString(),
                    EntertainerId = ev.EnterteinerId.ToString(),
                };
                e.Add(response);
            }
            GetEventsResponse getEventsResponse = new GetEventsResponse();
            getEventsResponse.Event.Add(e);
            return getEventsResponse;
        }
        public override async Task<GetEventResponse> CreateEvent(CreateEventRequest request, ServerCallContext context)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            Event e = new Event()
             {
                 Id = Guid.NewGuid(),
                 EnterteinerId = Guid.Parse(request.Entertainer),
                 CafeOwnerId = Guid.Parse(request.CafeOwner),
                 CreationDate = DateTime.Now.ToString(),
                 StartDate = request.StartDate,
                 EndDate = request.EndDate,
                 Text = request.Description,
                 Title = request.Name,
                 AvailablePlaces = request.AvailablePlaces
             };
            Event ev = await _eventRepository.CreateAsync(e);
            GetEventResponse response = new GetEventResponse()
            {
                Id = ev.Id.ToString(),
                Name = ev.Title.ToString(),
                Description = ev.Text.ToString(),
                CafeOwner = ev.CafeOwner.Username.ToString(),
                Entertainer = ev.Enterteiner.Username.ToString(),
                StartDate = ev.StartDate.ToString(),
                EndDate = ev.EndDate.ToString(),
                AvailablePlaces = ev.AvailablePlaces,
                State = ev.state.ToString(),
                CafeOwnerId = ev.CafeOwnerId.ToString(),
                EntertainerId = ev.EnterteinerId.ToString(),
            };
            try
            {
                return response;
            }
            catch (Exception ex) { return response; }
            
        }
        public override async Task<GetEventsByUserResponse> GetEventsByUser(GetRequest request, ServerCallContext context)
        {
            string id = request.Id;
            ICollection<Event> events = await _eventRepository.GetByAsync(e=>e.EnterteinerId.Equals(Guid.Parse(id)));
            //ICollection<Event> events = await _eventRepository.GetByAsync(e => e.AvailablePlaces==0);
            ICollection <GetEventByUserResponse> e = new List<GetEventByUserResponse>();
            foreach (Event ev in events)
            {
                GetEventByUserResponse response = new GetEventByUserResponse()
                {
                    Id = ev.Id.ToString(),
                    Name = ev.Title.ToString(),
                    Description = ev.Text.ToString(),
                    CafeOwnerId = ev.CafeOwnerId.ToString(),
                    EntertainerId = ev.EnterteinerId.ToString(),
                    StartDate = ev.StartDate.ToString(),
                    EndDate = ev.EndDate.ToString(),
                    AvailablePlaces = ev.AvailablePlaces,
                    State = ev.state.ToString(),
                    CafeOwner = ev.CafeOwner.Username,
                    Entertainer = ev.Enterteiner.Username,
                };
                e.Add(response);
            }
            GetEventsByUserResponse getEventsResponse = new GetEventsByUserResponse();
            getEventsResponse.Events.Add(e);
            return getEventsResponse;
        }

        public override async Task<GetEventResponse> GetEvent(GetRequest request, ServerCallContext context)
        {
            Event ev = await _eventRepository.GetByIdAsync(Guid.Parse(request.Id));
            DateTime dateTime = DateTime.Parse(ev.StartDate);
            GetEventResponse response = new GetEventResponse()
            {
                Id = ev.Id.ToString(),
                Name = ev.Title.ToString(),
                Description = ev.Text.ToString(),
                CafeOwner = ev.CafeOwner.Username.ToString(),
                Entertainer = ev.Enterteiner.Username.ToString(),
                StartDate = ev.StartDate.ToString(),
                EndDate = ev.EndDate.ToString(),
                AvailablePlaces = ev.AvailablePlaces,
                State = ev.state.ToString(),
                CafeOwnerId = ev.CafeOwnerId.ToString(),
                EntertainerId = ev.EnterteinerId.ToString(),
            };
            return response;
        }
        public override async Task<BookEventResponse> BookEvent(BookEventRequest request, ServerCallContext context)
        {
            Booking booking = new Booking()
            {
                Id = Guid.NewGuid(),
                UserId = Guid.Parse(request.UserId),
                EventId = Guid.Parse(request.EventId),
                CreationDate = DateTime.Now,
                NumberOfPeople = request.NumerOfPeople,
                FirstName = request.FirstName,
                LastName = request.LastName,
            };
            Booking b =  await _bookingRepository.CreateAsync(booking);
            BookEventResponse response = new BookEventResponse()
            {
                Id = booking.Id.ToString(),
                UserId = b.UserId.ToString(),
                EventId = b.EventId.ToString(),
                CreationDate = b.CreationDate.ToString(),
                NumerOfPeople = b.NumberOfPeople,
                FirstName = b.FirstName,
                LastName = b.LastName,
            };
            return response;
        }
        public override async Task<GetEventResponse> AcceptEvent(GetRequest request, ServerCallContext context)
        {
            Event @event = await _eventRepository.GetByIdAsync(Guid.Parse(request.Id));
            Event result = await _eventRepository.AcceptEventAsync(@event);
            GetEventResponse response = new GetEventResponse()
            {
                Id = result.Id.ToString(),
                Name = result.Title.ToString(),
                Description = result.Text.ToString(),
                CafeOwner = result.CafeOwner.Username.ToString(),
                Entertainer = result.Enterteiner.Username.ToString(),
                StartDate = result.StartDate.ToString(),
                EndDate = result.EndDate.ToString(),
                AvailablePlaces = result.AvailablePlaces,
                State = result.state.ToString(),
                CafeOwnerId = result.CafeOwnerId.ToString(),
                EntertainerId = result.EnterteinerId.ToString(),

            };
            return response;
        }
        public override async Task<GetEventResponse> RefuseEvent(GetRequest request, ServerCallContext context)
        {

            Event @event = await _eventRepository.GetByIdAsync(Guid.Parse(request.Id));
            Event result = await _eventRepository.RefuseEventAsync(@event);
            GetEventResponse response = new GetEventResponse()
            {
                Id = result.Id.ToString(),
                Name = result.Title.ToString(),
                Description = result.Text.ToString(),
                CafeOwner = result.CafeOwner.Username.ToString(),
                Entertainer = result.Enterteiner.Username.ToString(),
                StartDate = result.StartDate.ToString(),
                EndDate = result.EndDate.ToString(),
                AvailablePlaces = result.AvailablePlaces,
                State = result.state.ToString(),
                CafeOwnerId = result.CafeOwnerId.ToString(),
                EntertainerId = result.EnterteinerId.ToString(),
            };
            return response;
        }
        public override async Task<GetEventResponse> ReverseState(GetRequest request, ServerCallContext context)
        {

            Event @event = await _eventRepository.GetByIdAsync(Guid.Parse(request.Id));
            Event result = await _eventRepository.RevertStateAsync(@event);
            GetEventResponse response = new GetEventResponse()
            {
                Id = result.Id.ToString(),
                Name = result.Title.ToString(),
                Description = result.Text.ToString(),
                CafeOwner = result.CafeOwner.Username.ToString(),
                Entertainer = result.Enterteiner.Username.ToString(),
                StartDate = result.StartDate.ToString(),
                EndDate = result.EndDate.ToString(),
                AvailablePlaces = result.AvailablePlaces,
                State = result.state.ToString(),
                CafeOwnerId = result.CafeOwnerId.ToString(),
                EntertainerId = result.EnterteinerId.ToString(),
            };
            return response;
        }
    }
}