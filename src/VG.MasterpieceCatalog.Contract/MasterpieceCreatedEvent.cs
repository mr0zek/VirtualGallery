namespace VG.MasterpieceCatalog.Contract
{
  public class MasterpieceCreatedEvent : Event
  {
    public string Name { get; set; }
    public decimal Price { get; set; }
  }
}