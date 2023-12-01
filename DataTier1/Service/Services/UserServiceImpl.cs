using Data.Interfaces;
using Data.Models;
using Grpc.Core;

namespace Service.Services
{
    public class UserServiceImpl : UserService.UserServiceBase
    {
        private readonly ILogger<EventServiceImpl> _logger;
        private readonly IAuthRepository _authRepository;
       
        public UserServiceImpl(ILogger<EventServiceImpl> logger, IAuthRepository authRepository)
        {
            _logger = logger;
            _authRepository = authRepository;
        }

        public override async Task<CreateUserResponse> CreateUser(CreateUserRequest request, ServerCallContext context)
        {
            try
            {
                User user = new()
                {
                    Id = Guid.NewGuid(),
                    Firstname = request.FisrtName,
                    Lastname = request.LastName,
                    Username = request.FisrtName + request.LastName,
                    Email = request.Email,
                    CreationDate = DateTime.Now,
                    Role = (Role)Enum.Parse(typeof(Role), request.Role),
                    PasswordHash = request.Password
                };

                User createdUser = await _authRepository.RegisterUserAsync(user);

                CreateUserResponse response = new()
                {
                    FisrtName = createdUser.Firstname,
                    LastName = createdUser.Lastname,
                    Username = createdUser.Username,
                    Email = createdUser.Email,
                    Role = createdUser.Role.ToString(),
                    Id = createdUser.Id.ToString(),
                };

                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public override async Task<LoginResponse> LoginUser(LoginRequest request, ServerCallContext context)
        {
            Auth auth = new()
            {
                Email = request.Email,
                Password = request.Password
            };

            LoginResponse response = new()
            {
                IsSuccessful = await _authRepository.LoginUserAsync(auth)
            };

            return response;
        }
    }
}
