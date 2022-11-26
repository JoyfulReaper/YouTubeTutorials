using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.Guest;

public sealed class Guest : AggregateRoot<GuestId>
{
    private List<DinnerId> _upcomingDinnerIds = new();
    private List<DinnerId> _pastDinnerIds = new();
    private List<DinnerId> _pendingDinnerIds = new();
    private List<BillId> _billIds = new();
    private List<MenuReviewId> _menuReviews = new();


    private Guest(
        GuestId guestId,
        string firstName,
        string lastName,
        string profileImage,
        UserId userID,
        DateTime createdDateTime,
        DateTime updatedDateTime
    ) :base(guestId)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        UserId = userID;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }
    public string FirstName {get;}
    public string LastName {get;}
    public string ProfileImage {get;}
    public AverageRating AverageRating {get;}
    public UserId UserId;

    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public static Guest Create(
        string firstName,
        string lastName,
        string profileImage,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime
    )
    {
        return new(GuestId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow
            );
    }
}