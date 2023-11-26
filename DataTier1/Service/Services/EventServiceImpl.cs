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
        private readonly IBookingRepository _bookingRepository;
        public EventServiceImpl(ILogger<EventServiceImpl> logger, IEventRepository eventRepository, IBookingRepository bookingRepository)
        {
            _logger = logger;
            _eventRepository = eventRepository;
            _bookingRepository = bookingRepository;
        }
        public override async Task<CreateEventResponse> CreateEvent(CreateEventRequest request, ServerCallContext context)
        {
            Event e = new Event()
            {
                Id = Guid.NewGuid(),
                EnterteinerId = Guid.Parse(request.Entertainer),
                CafeOwnerId = Guid.Parse(request.Entertainer),
                CreationDate = DateTime.Now,
                Date = DateTime.Parse(request.Date),
                Text = request.Description,
                Title = request.Name,
                AvailablePlaces = 10 //request.AvailablePlaces
            };
            Event ev = await _eventRepository.CreateAsync(e);
            CreateEventResponse response = new CreateEventResponse()
            {
                Id = ev.Id.ToString(),
                Entertainer = ev.EnterteinerId.ToString(),
                Name = ev.Title,
                Description = ev.Text,
                AvailablePlaces = ev.AvailablePlaces
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
        public override async Task<BookEventResponse> BookEvent(BookEventRequest request, ServerCallContext context)
        {
            Booking booking = new Booking()
            {
                Id = Guid.NewGuid(),
                UserId = Guid.Parse(request.UserId),
                EventId = Guid.Parse(request.EventId),
                CreationDate = DateTime.Parse(request.Date),
                NumberOfPeople = request.NumerOfPeople
            };
            Booking b =  await _bookingRepository.CreateAsync(booking);
            BookEventResponse response = new BookEventResponse()
            {
                Id = booking.Id.ToString(),
                UserId = b.UserId.ToString(),
                EventId = b.EventId.ToString(),
                Date = b.CreationDate.ToString(),
                NumerOfPeople = b.NumberOfPeople
            };
            return response;
        }

    }
}