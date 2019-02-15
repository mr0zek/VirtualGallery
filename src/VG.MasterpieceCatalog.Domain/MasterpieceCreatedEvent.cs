﻿using VG.MasterpieceCatalog.Domain.BaseTypes;

namespace VG.MasterpieceCatalog.Domain
{
  public class MasterpieceCreatedEvent : IEvent
  {
    public string AggregateId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
  }
}