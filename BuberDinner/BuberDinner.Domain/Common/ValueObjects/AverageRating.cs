using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects;

public sealed class AverageRating : ValueObject
{
    private AverageRating(float value, int numRatings)
    {
        Value = value;
        NumRatings = numRatings;
    }

    public float Value { get; private set; }
    public int NumRatings { get; private set; }

    public static AverageRating CreateNew(float rating = 0, int numRatings = 0)
    {
        return new AverageRating(rating, numRatings);
    }

    public void AddNewRating(Rating rating)
    {
        Value = ((Value * NumRatings) + rating.Value) / ++NumRatings;
    }

    public void RemoveRating(Rating rating)
    {
        Value = ((Value * NumRatings) - rating.Value / --NumRatings);
    }

    public override IEnumerable<Object> GetEqualityComponents()
    {
        yield return Value;
    }
}