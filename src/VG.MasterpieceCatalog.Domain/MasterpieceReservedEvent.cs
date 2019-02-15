using System;
using VG.MasterpieceCatalog.Domain.BaseTypes;

namespace VG.MasterpieceCatalog.Domain
{
  public class MasterpieceReservedEvent : IEvent
  {
    public string AggregateId { get; set; }
    public CustomerId CustomerId { get; set; }
    public int Version { get; set; }

    public MasterpieceReservedEvent()
    {
    }

    public MasterpieceReservedEvent(MasterpieceId id, CustomerId customerId, int version)
    {
      AggregateId = id;
      CustomerId = customerId;
      Version = version;
    }
  }
}