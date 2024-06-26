using CSharpFunctionalExtensions;
using ValueObject = Order.Core.Common.ValueObject;
namespace Order.Core.ValueObjects;
public class Money : ValueObject
{
    private Money(string currency, decimal price)
    {
        Currency = currency;
        Price = price;
    }

    private Money() { }
    public string Currency { get; } = null!;
    public decimal Price { get; } 

    public static Result<Money> Create(string currency, decimal price)
    {
        if (currency.Length == 0)
            return Result.Failure<Money>("Введите вашу валюту");

        if (price <= 0)
            return Result.Failure<Money>("Цена не может быть меньше или равна нулю");

        return Result.Success(new Money(currency, price));
    }
    protected override IEnumerable<object> GetEq()
    {
        yield return Currency;
        yield return Price;

    }

}

