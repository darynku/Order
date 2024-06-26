using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Order.Core.Entities;
using Order.Infrastructure.DbContexts;


namespace Order.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Register(AppUser user, CancellationToken ct)
        {
            await _context.Users.AddAsync(user, ct);
            await _context.SaveChangesAsync(ct);

        }
        public async Task Add(AppUser user, CancellationToken ct)
        {
            await _context.AddAsync(user, ct);
        }
        public async Task<Result<AppUser>> GetByEmail(string email, CancellationToken ct)
        {
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == email, cancellationToken: ct);

            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return user;
        }
    }
}
