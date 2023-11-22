using Data.Interfaces;
using Data.Models;
using Data.Repositories;
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
            CreateEventResponse response = new CreateEventResponse()
            {
                Id = ev.Id.ToString(),
                Entertainer = ev.EnterteinerId.ToString(),
                Name = ev.Title,
                Description = ev.Text
            };
            return response;
        }
        public override async Task<GetEventResponse> GetEvent(GetEventRequest request, ServerCallContext context)
        {
            Event ev = await _eventRepository.GetByIdAsync(Guid.Parse(request.Id));
            GetEventResponse response = new GetEventResponse()
            {
                Id = ev.Id.ToString(),
                Name = ev.Title.ToString(),
                Description = ev.Text.ToString(),
                CafeOwner = ev.CafeOwnerId.ToString(),
                Entertainer = ev.EnterteinerId.ToString(),
                Date = ev.Date.ToString(),
            };
            return response;
        }
    }
}