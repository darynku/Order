using FluentValidation;
using Order.Application.Features.Orders.Post;

namespace Order.Application.Features.Orders.Create
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(10, 100)
                .WithMessage("Слишком длинное или короткое название");

            RuleFor(x => x.Price)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Цена не может быть меньше 0");
        }
    }
}
