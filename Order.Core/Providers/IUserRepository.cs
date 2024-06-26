using CSharpFunctionalExtensions;
using Order.Core.Entities;

namespace Order.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task Add(AppUser user, CancellationToken ct);
        Task<Result<AppUser>> GetByEmail(string email, CancellationToken ct);
        Task Register(AppUser user, CancellationToken ct);
    }
}