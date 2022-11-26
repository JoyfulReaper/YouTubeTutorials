using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects;

public sealed class Rating : ValueObject
{
    public int Value { get; private set; }

    private Rating(int value)
    {
        Value = value;
    }

    public Rating CreateNew(int rating)
    {
        return new Rating(rating);
    }

    public override IEnumerable<Object> GetEqualityComponents()
    {
        yield return Value;
    }
}