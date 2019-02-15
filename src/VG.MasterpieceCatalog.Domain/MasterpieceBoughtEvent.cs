using System;
using VG.MasterpieceCatalog.Domain.BaseTypes;

namespace VG.MasterpieceCatalog.Domain
{
  public class MasterpieceBoughtEvent : IEvent
  {
    public string AggregateId { get; set; }

    public string CustomerId { get; }

    public MasterpieceBoughtEvent(MasterpieceId aggregateId, CustomerId customerId)
    {
      AggregateId = aggregateId;
      CustomerId = customerId;
    }    
  }
}