using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;

namespace BuberDinner.Domain.GuestAggregate.Entities;

public sealed class GuestRating : Entity<GuestRatingId>
{
    private GuestRating(GuestRatingId guestRatingId,
    HostId hostId,
    DinnerId dinnerId,
    int rating) : base(guestRatingId)
    {
        HostId = hostId;
        DinnerId = dinnerId;
        Rating = rating;
    }

    public HostId HostId { get; }
    public DinnerId DinnerId {get;}
    public int Rating { get; set; }

    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public static GuestRating Create(
        HostId hostId,
        DinnerId dinnerId,
        int rating
    )
    {
        return new(GuestRatingId.CreateUnique(),
            hostId,
            dinnerId,
            rating);
    }
}