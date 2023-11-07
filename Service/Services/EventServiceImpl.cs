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