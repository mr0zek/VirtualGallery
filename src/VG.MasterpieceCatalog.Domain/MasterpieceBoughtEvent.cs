using System;
using VG.MasterpieceCatalog.Domain.BaseTypes;

namespace VG.MasterpieceCatalog.Domain
{
  public class MasterpieceBoughtEvent : IEvent
  {
    public string AggregateId { get; set; }

    public string CustomerId { get; }

    public MasterpieceBoughtEvent(string aggregateId, string customerId)
    {
      AggregateId = aggregateId;
      CustomerId = customerId;
    }    
  }
}