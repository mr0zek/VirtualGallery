using System;
using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Contract
{
  public class MasterpieceBoughtEvent 
  {
    public MasterpieceId MasterpieceId { get; }
    public CustomerId CustomerId { get; }
    
    public MasterpieceBoughtEvent(MasterpieceId masterpieceId, CustomerId customerId, int version)
    {
      MasterpieceId = masterpieceId;
      CustomerId = customerId;
      Version = version;
    }    
  }
}