namespace VG.Notification.ExternalInterfaces
{
  public class RevokedMasterpieceReservationEvent : IEvent
  {
    public string AggregateId { get; set; }

    public string CustomerId { get; }

    public int Version { get; set; }

    public RevokedMasterpieceReservationEvent(string masterpieceId, string customerId, int version)
    {
      AggregateId = masterpieceId;
      CustomerId = customerId;
      Version = version;
    }
  }
}