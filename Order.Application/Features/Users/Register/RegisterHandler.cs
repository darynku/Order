using CSharpFunctionalExtensions;
using Order.Core.Entities;
using Order.Infrastructure.Providers;
using Order.Infrastructure.Repositories;

namespace Order.Application.Features.Users.Register
{
    public class RegisterHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RegisterHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<AppUser>> Register(string userName, string email, string password, CancellationToken ct)
        {
            var passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(password);

            var user = AppUser.Create(Guid.NewGuid(), userName, email, passwordHash);

            await _userRepository.Register(user.Value, ct);

            if (user.Value is null)
                return Result.Failure<AppUser>("Failed to register");

            return user;
        } 
    }
}
