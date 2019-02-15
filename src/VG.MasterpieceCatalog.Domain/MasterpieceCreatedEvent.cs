using VG.MasterpieceCatalog.Domain.BaseTypes;

namespace VG.MasterpieceCatalog.Domain
{
  public class MasterpieceCreatedEvent : IEvent
  {
    public int Version { get; set; }
    public string AggregateId { get; set; }
    public string Name { get; set; }
    public Money Price { get; set; }
  }
}