namespace VG.MasterpieceCatalog.Contract
{
  public class MasterpieceBoughtEvent : IEvent
  {
    public string AggregateId { get; set; }

    public string CustomerId { get; }  
  }
}