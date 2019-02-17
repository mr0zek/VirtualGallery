namespace VG.MasterpieceCatalog.Contract
{
  public class MasterpieceBoughtEvent : Event
  {
    public string AggregateId { get; set; }
    public string CustomerId { get; }  
  }
}