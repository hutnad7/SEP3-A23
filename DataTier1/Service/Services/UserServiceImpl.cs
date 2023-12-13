using Data.Interfaces;
using Data.Models;
using Data.Repositories;
using Grpc.Core;
using Service.Utils;

namespace Service.Services
{
    public class UserServiceImpl : UserService.UserServiceBase
    {
        private readonly ILogger<EventServiceImpl> _logger;
        private readonly IAuthRepository _authRepository;
        private readonly IEnterteinerRepository _enterteinerRepository;

        public UserServiceImpl(ILogger<EventServiceImpl> logger, IAuthRepository authRepository, IEnterteinerRepository enterteinerRepository)
        {
            _logger = logger;
            _authRepository = authRepository;   
            _enterteinerRepository = enterteinerRepository;
        }

        public override async Task<CreateUserResponse> CreateUser(CreateUserRequest request, ServerCallContext context)
        {
            try
            {
                string hashedPassword = PasswordHasher.HashPassword(request.Password);
                
                User user = new()
                {
                    Id = Guid.NewGuid(),
                    FirstName = request.FisrtName,
                    LastName = request.LastName,
                    Username = request.Email,
                    Email = request.Email,
                    CreationDate = DateTime.Now.ToString(),
                    Role = Enum.Parse<Role>(request.Role),
                    PasswordHash = hashedPassword,
                    Description = request.Description
                };

                User createdUser = await _authRepository.RegisterUserAsync(user);

                CreateUserResponse response = new()
                {
                    FisrtName = createdUser.FirstName,
                    LastName = createdUser.LastName,
                    Username = createdUser.Username,
                    Email = createdUser.Email,
                    Role = createdUser.Role.ToString(),
                    Id = createdUser.Id.ToString(),
                    Description = createdUser.Description
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

            if (foundUser == null)
            {
                throw new Exception("User not found");
            }

            if (!PasswordHasher.VerifyPassword(foundUser.PasswordHash, auth.Password))
            {
                throw new Exception("Wrong password");
            }

            CreateUserResponse response = new()
            {
                FisrtName = foundUser.FirstName,
                LastName = foundUser.LastName,
                Username = foundUser.Username,
                Email = foundUser.Email,
                Role = foundUser.Role.ToString(),
                Id = foundUser.Id.ToString(),
            };

            return response;
        }
        public override async Task<GetUsersResponse> GetAllEntertainers(Google.Protobuf.WellKnownTypes.Empty request, ServerCallContext context)
        {
            ICollection<User> users = await _enterteinerRepository.GetAll();
            ICollection<GetUserResponse> response = new List<GetUserResponse>();
            foreach (User user in users)
            {
                GetUserResponse u = new GetUserResponse()
                {
                    Id = user.Id.ToString(),
                    Description = user.Description,
                    FirstName = user.FirstName, 
                    LastName = user.LastName,
                    Username= user.Username,
                    Role = user.Role.ToString(),
                };
                response.Add(u);
            }
            GetUsersResponse getUsersResponse = new GetUsersResponse();
            getUsersResponse.User.Add(response);
            return getUsersResponse;
        }
    }
}
