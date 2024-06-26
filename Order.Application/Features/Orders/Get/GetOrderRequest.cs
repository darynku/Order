using Order.Core.Entities;
using Order.Core.ValueObjects;
using MediatR;
using System.Text.Json.Serialization;
using Order.Application.DTO.Orders;
using CSharpFunctionalExtensions;

namespace Order.Application.Features.Orders.Get
{
    public record GetOrderRequest(Guid Id) : IRequest<Result>;
}
