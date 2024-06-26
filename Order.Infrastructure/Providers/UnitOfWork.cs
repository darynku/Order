using Order.Infrastructure.DbContexts;

namespace Order.Infrastructure.Providers
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangeAsync(CancellationToken ct)
        {
            return await _context.SaveChangesAsync(ct);
        }
    }
}
