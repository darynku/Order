using CSharpFunctionalExtensions;
using MediatR;
using Order.Core.Entities;

namespace Order.Application.Features.Orders.Post
{
    public record CreateOrderCommand(
        string Name,
        string Description,
        DateTime OrderDate,
        DateTime ShippedDate,
        string Currency,
        decimal Price) : IRequest<Result>;
}
