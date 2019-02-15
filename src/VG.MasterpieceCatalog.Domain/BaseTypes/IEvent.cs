namespace VG.MasterpieceCatalog.Domain.BaseTypes
{
  public interface IEvent
  {
    int Version { get; }
    string AggregateId { get; set; }
  }
}