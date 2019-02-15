namespace VG.MasterpieceCatalog.Contract
{
  public class RevokedMasterpieceReservationEvent : IEvent
  {
    public string AggregateId { get; set; }
    public string CustomerId { get; }
  }
}