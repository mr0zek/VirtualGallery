namespace VG.MasterpieceCatalog.Contract
{
  public class MasterpieceReservedEvent :Event
  {
    public string AggregateId { get; set; }
    public string CustomerId { get; set; }
  }
}