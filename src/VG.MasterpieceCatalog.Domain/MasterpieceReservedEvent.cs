using System;

namespace VG.MasterpieceCatalog.Domain
{
  public class MasterpieceReservedEvent : IEvent
  {
    public Guid Id { get; }
    public CustomerId CustomerId { get; }
    public int Version { get; }

    public MasterpieceReservedEvent(Guid id, CustomerId customerId, int version)
    {
      Id = id;
      CustomerId = customerId;
      Version = version;
    }
  }
}