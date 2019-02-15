using VG.MasterpieceCatalog.Domain.BaseTypes;

namespace VG.MasterpieceCatalog.Domain
{
  public class MasterpieceRemovedEvent : IEvent
  {
    public string AggregateId { get; set; }

    public MasterpieceRemovedEvent(MasterpieceId aggregateId)
    {
      AggregateId = aggregateId;
    }    
  }
}