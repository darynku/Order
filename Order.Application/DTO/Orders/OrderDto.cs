using MediatR;
using Order.Core.Entities;
using Order.Core.ValueObjects;

namespace Order.Application.DTO.Orders
{
    public record OrderDto(
            string Name,
            string Description,
            DateTime OrderDate,
            DateTime ShippedDate,
            string Currency,
            decimal Price,
            string Status);
}
