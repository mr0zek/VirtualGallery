﻿namespace VG.MasterpieceCatalog.Contract
{
  public class MasterpieceReservedEvent : IEvent
  {
    public string AggregateId { get; set; }
    public string CustomerId { get; set; }
  }
}