using System;
using VG.MasterpieceCatalog.Domain.BaseTypes;

namespace VG.MasterpieceCatalog.Domain
{
  public class RevokedMasterpieceReservationEvent : IEvent
  {
    public string AggregateId { get; set; }
    public CustomerId CustomerId { get; }
    public int Version { get; }

    public RevokedMasterpieceReservationEvent(MasterpieceId id, CustomerId customerId, int version)
    {
      AggregateId = id;
      CustomerId = customerId;
      Version = version;
    }
  }
}