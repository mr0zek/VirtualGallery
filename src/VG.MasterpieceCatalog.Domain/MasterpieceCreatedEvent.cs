using System;
using VG.MasterpieceCatalog.Domain.BaseTypes;

namespace VG.MasterpieceCatalog.Domain
{
  public class MasterpieceCreatedEvent : IEvent
  {
    public string AggregateId { get; set; }
    public string Name { get; set; }
    public DateTime Produced { get; set; }
    public decimal Price { get; set; }

    public MasterpieceCreatedEvent(string aggregateId, string name, DateTime produced, decimal price)
    {
      AggregateId = aggregateId;
      Name = name;
      Produced = produced;
      Price = price;
    }
  }
}