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
                    Username = request.Email + "u",
                    Email = request.Email,
                    CreationDate = DateTime.Now.ToString(),
                    Role = (Role)Enum.Parse(request.Role),
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

        public override async Task<CreateUserResponse> LoginUser(LoginRequest request, ServerCallContext context)
        {
            Auth auth = new()
            {
                Email = request.Email,
                Password = request.Password
            };

            User? foundUser = await _authRepository.LoginUserAsync(auth);

            CreateUserResponse response = new()
            {
                FisrtName = foundUser.Firstname,
                LastName = foundUser.Lastname,
                Username = foundUser.Username,
                Email = foundUser.Email,
                Role = foundUser.Role.ToString(),
                Id = foundUser.Id.ToString(),
            };

            return response;
        }
    }
}
