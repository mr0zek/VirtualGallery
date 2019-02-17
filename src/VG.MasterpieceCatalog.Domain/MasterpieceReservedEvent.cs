using System;
using VG.MasterpieceCatalog.Domain.BaseTypes;

namespace VG.MasterpieceCatalog.Domain
{
  public class MasterpieceReservedEvent : IEvent
  {
    public string AggregateId { get; set; }
    public string CustomerId { get; set; }

    public MasterpieceReservedEvent(string aggregateId, string customerId)
    {
      AggregateId = aggregateId;
      CustomerId = customerId;
    }
  }
}