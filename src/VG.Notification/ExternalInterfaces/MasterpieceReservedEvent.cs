namespace VG.Notification.ExternalInterfaces
{
  public class MasterpieceReservedEvent : IEvent
  {
    public string AggregateId { get; set; }

    public string CustomerId { get; }

    public int Version { get; set; }

    public MasterpieceReservedEvent(string masterpieceId, string customerId, int version)
    {
      AggregateId = masterpieceId;
      CustomerId = customerId;
      Version = version;
    }
  }
}