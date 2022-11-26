using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.GuestAggregate.ValueObjects;

public sealed class GuestId : ValueObject
{
    public Guid Value { get; }

    private GuestId(Guid value)
    {
        Value = value;
    }

    public static GuestId Create(string guestId)
    {
        return new(Guid.Parse(guestId));
    }

    public static GuestId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}