﻿using System;

namespace VG.MasterpieceCatalog.Domain
{
  public class RevokedMasterpieceReservationEvent : IEvent
  {
    public MasterpieceId Id { get; }
    public CustomerId CustomerId { get; }
    public int Version { get; }

    public RevokedMasterpieceReservationEvent(MasterpieceId id, CustomerId customerId, int version)
    {
      Id = id;
      CustomerId = customerId;
      Version = version;
    }
  }
}