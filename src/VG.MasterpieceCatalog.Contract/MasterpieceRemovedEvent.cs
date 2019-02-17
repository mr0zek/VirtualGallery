namespace VG.MasterpieceCatalog.Contract
{
  public class MasterpieceRemovedEvent : Event
  {
    public string AggregateId { get; set; }
  }
}