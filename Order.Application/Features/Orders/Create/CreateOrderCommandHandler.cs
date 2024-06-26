using CSharpFunctionalExtensions;
using MediatR;
using Order.Core.Entities;
using Order.Core.ValueObjects;
using Order.Infrastructure.Providers;
using Order.Infrastructure.Repositories;

namespace Order.Application.Features.Orders.Post
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateOrderCommandHandler(IOrdersRepository ordersRepository, IUnitOfWork unitOfWork)
        {
            _ordersRepository = ordersRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var money = Money.Create(request.Currency, request.Price);

            var order = OrderEntity.Create(
                Guid.NewGuid(), 
                request.Name,
                request.Description, 
                request.OrderDate, 
                request.ShippedDate, 
                money.Value,
                []);

            if (order.IsFailure)
                return Result.Failure<OrderEntity>("Пустое значение заказа");

            await _ordersRepository.AddAsync(order.Value, cancellationToken);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return Result.Success();
        }
    }
}

