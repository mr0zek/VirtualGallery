﻿namespace VG.MasterpieceCatalog.Contract
{
  public class RevokedMasterpieceReservationEvent : Event
  {
    public string AggregateId { get; set; }
    public string CustomerId { get; }
  }
}