using CSharpFunctionalExtensions;
using MediatR;
using Order.Infrastructure.Repositories;

namespace Order.Application.Features.Orders.Get
{
    public class GetOrderRequestHandler : IRequestHandler<GetOrderRequest, Result>
    {
        private readonly IOrdersRepository _ordersRepository;
        public GetOrderRequestHandler(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task<Result> Handle(GetOrderRequest request, CancellationToken cancellationToken)
        {
            var order = await _ordersRepository.GetOrderAsync(request.Id, cancellationToken);
            if (order.IsFailure)
                Result.Failure<GetOrderRequest>("Fail to get order");
            if (order.Value is null)
                throw new ArgumentNullException(nameof(order.Value));

            return Result.Success(order);
        }
    }
}
