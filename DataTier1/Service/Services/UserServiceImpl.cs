using Data.Interfaces;

namespace Service.Services
{
    public class UserServiceImpl : UserService.UserServiceBase
    {
        private readonly ICafeOwnerRepository _eventRepository;
        public UserServiceImpl(ILogger<EventServiceImpl> logger, ICafeOwnerRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

    }
}
