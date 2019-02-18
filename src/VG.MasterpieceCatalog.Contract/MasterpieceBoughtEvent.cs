namespace VG.MasterpieceCatalog.Contract
{
  public class MasterpieceBoughtEvent : Event
  {
    public string CustomerId { get; set; }  
  }
}