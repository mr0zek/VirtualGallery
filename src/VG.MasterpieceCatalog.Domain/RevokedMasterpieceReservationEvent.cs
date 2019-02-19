﻿using System;
using VG.MasterpieceCatalog.Domain.BaseTypes;

namespace VG.MasterpieceCatalog.Domain
{
  public class RevokedMasterpieceReservationEvent : IEvent
  {
    public string AggregateId { get; set; }
    public string CustomerId { get; }

    public RevokedMasterpieceReservationEvent(string aggregateId, string customerId)
    {
      AggregateId = aggregateId;
      CustomerId = customerId;
    }
  }
}