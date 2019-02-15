namespace VG.MasterpieceCatalog.Domain.BaseTypes
{
  public interface IEvent
  {
    string AggregateId { get; set; }
  }
}