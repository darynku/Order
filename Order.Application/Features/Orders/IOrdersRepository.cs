using CSharpFunctionalExtensions;
using Order.Application.DTO.Orders;
using Order.Core.Entities;
namespace Order.Infrastructure.Repositories
{
    public interface IOrdersRepository
    {
        Task<Result<OrderEntity>> GetOrderAsync(Guid id, CancellationToken ct);
        Task AddAsync(OrderEntity orderEntity, CancellationToken ct);
    }
}