using Data.Interfaces;
using Data.Models;
using Data.Repositories;
using Google.Protobuf.WellKnownTypes;
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
                    CafeOwner = ev.CafeOwnerId.ToString(),
                    Entertainer = ev.EnterteinerId.ToString(),
                    Date = ev.Date.ToString(),
                };
                e.Add(response);
            }
            GetEventsResponse getEventsResponse = new GetEventsResponse(); 
            getEventsResponse.Event.Add(e);
            return getEventsResponse;
        }
        public override async Task<CreateEventResponse> CreateEvent(CreateEventRequest request, ServerCallContext context)
        {
             Event e = new Event()
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
    }
}