namespace VG.Notification.ExternalInterfaces
{
  public class MasterpieceBoughtEvent : IEvent
  {
    public string AggregateId { get; set; }

    public string CustomerId { get; }

    public int Version { get; set; }

    public MasterpieceBoughtEvent(string masterpieceId, string customerId, int version)
    {
      AggregateId = masterpieceId;
      CustomerId = customerId;
      Version = version;
    }    
  }
}