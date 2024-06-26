using AutoMapper;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Order.Application.DTO.Orders;
using Order.Application.Features.Orders.Get;
using Order.Core.Entities;
using Order.Core.ValueObjects;
using Order.Infrastructure.DbContexts;

namespace Order.Infrastructure.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly ApplicationDbContext _context;
        public OrdersRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<OrderEntity>> GetOrderAsync(Guid Id, CancellationToken ct)
        {
            var order = await _context.Orders
                .Include(x => x.OrderItems)
                .FirstOrDefaultAsync(x => x.Id == Id, ct);
            if (order is null)
                throw new ArgumentNullException(nameof(order));

            return order;
        }
        
        public async Task AddAsync(OrderEntity orderEntity, CancellationToken ct)
        {
             await _context.Orders.AddAsync(orderEntity, ct);
        }
    }
}
