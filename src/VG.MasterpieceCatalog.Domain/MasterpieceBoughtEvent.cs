using System;
using VG.MasterpieceCatalog.Domain.BaseTypes;

namespace VG.MasterpieceCatalog.Domain
{
  public class MasterpieceBoughtEvent : IEvent
  {
    public string AggregateId { get; set; }

    public CustomerId CustomerId { get; }

    public int Version { get; set; }

    public MasterpieceBoughtEvent(MasterpieceId masterpieceId, CustomerId customerId, int version)
    {
      AggregateId = masterpieceId;
      CustomerId = customerId;
      Version = version;
    }    
  }
}