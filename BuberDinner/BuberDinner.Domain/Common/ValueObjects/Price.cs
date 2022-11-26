using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects;

public sealed class Price : ValueObject
{
    public decimal Amount { get; }
    public string Currency { get; }

    private Price(int amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public Price CreateNew(int amount, string currency)
    {
        return new Price(amount, currency);
    }

    public override IEnumerable<Object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}