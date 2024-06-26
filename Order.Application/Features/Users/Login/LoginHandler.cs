using CSharpFunctionalExtensions;
using Order.Infrastructure.Providers;
using Order.Infrastructure.Repositories;

namespace Order.Application.Features.User.Login
{
    public class LoginHandler
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly IUserRepository _userRepository;
        public LoginHandler(IJwtProvider jwtProvider, IUserRepository userRepository)
        {
            _jwtProvider = jwtProvider;
            _userRepository = userRepository;
        }
        public async Task<Result<string>> Login(LoginRequest request, CancellationToken ct)
        {
            var user = await _userRepository.GetByEmail(request.Email, ct);

            if(user.IsFailure)
               return user.Error;

            var isVerified = BCrypt.Net.BCrypt.EnhancedVerify(request.Password, user.Value.PasswordHash);
            if(isVerified is false)
                return user.Error;

            var token = _jwtProvider.Generate(user.Value);

            return token;
        }
    }
}
