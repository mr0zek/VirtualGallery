namespace VG.MasterpieceCatalog.Contract
{
  public class MasterpieceRemovedEvent : IEvent
  {
    public string AggregateId { get; set; }
  }
}