using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.Enums;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;

namespace BuberDinner.Domain.DinnerAggregate.Entities;

public sealed class Reservation : Entity<ReservationId>
{

    public int GuestCount {get;}
    public ReservationStatus ReservationStatus {get;}
    public GuestId GuestId { get; }
    public BillId BillId { get; }
    public DateTime ArrivalTime { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Reservation(
        ReservationId reservationId,
        int guestCount,
        GuestId guestId,
        BillId billId,
        DateTime arrivalTime,
        DateTime createdDateTime,
        DateTime updateDateTime
    ) : base (reservationId)
    {
        GuestCount = guestCount;
        GuestId = guestId;
        BillId = billId;
        ArrivalTime = arrivalTime;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updateDateTime;
    }

    public static Reservation Create(
        int guestCount,
        GuestId guestId,
        BillId billId,
        DateTime arrivalTime,
        DateTime createdDateTime,
        DateTime updateDateTime
    )
    {
        return new(ReservationId.CreateUnique(),
            guestCount,
            guestId,
            billId,
            arrivalTime,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}