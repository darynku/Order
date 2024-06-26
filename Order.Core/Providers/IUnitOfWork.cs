
namespace Order.Infrastructure.Providers
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangeAsync(CancellationToken ct);
    }
}