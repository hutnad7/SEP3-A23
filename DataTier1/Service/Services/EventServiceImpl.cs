using Data.Interfaces;
using Data.Models;
using Grpc.Core;

namespace Service.Services
{
    public class EventServiceImpl : EventService.EventServiceBase
    {
        private readonly ILogger<EventServiceImpl> _logger;
        private readonly IEventRepository _eventRepository;
        public EventServiceImpl(ILogger<EventServiceImpl> logger, IEventRepository eventRepository)
        {
            _logger = logger;
            _eventRepository = eventRepository;
        }
        public override async Task<EventResponse> CreateEvent(EventRequest request, ServerCallContext context)
        {
<<<<<<< Updated upstream
            Event e = new Event()
=======
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
            ICollection <GetEventResponse> e = new List<GetEventResponse>();
            foreach (Event ev in events)
            {
                GetEventResponse response = new GetEventResponse()
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
>>>>>>> Stashed changes
            {
                Id = Guid.NewGuid(),
                EnterteinerId = Guid.Parse(request.Entertainer),
                CafeOwnerId = Guid.Parse(request.CafeOwner),
                CreationDate = DateTime.Now,
                Date = DateTime.Parse(request.Date),
                Text = request.Description,
                Title = request.Name
            };
            Event ev = await _eventRepository.CreateAsync(e);
            EventResponse response = new EventResponse()
            {
                Id = ev.Id.ToString(),
                Entertainer = ev.EnterteinerId.ToString(),
                Name = ev.Title,
                Description = ev.Text
            };
            return response;
        }
<<<<<<< Updated upstream
=======
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

>>>>>>> Stashed changes
    }
}