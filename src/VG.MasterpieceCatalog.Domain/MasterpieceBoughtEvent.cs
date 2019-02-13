using System;

namespace VG.MasterpieceCatalog.Domain
{
  public class MasterpieceBoughtEvent : IEvent
  {
    public MasterpieceId Id { get; }
    public CustomerId CustomerId { get; }
    public int Version { get; set; }

    public MasterpieceBoughtEvent(MasterpieceId id, CustomerId customerId, int version)
    {
      Id = id;
      CustomerId = customerId;
      Version = version;
    }    
  }
}