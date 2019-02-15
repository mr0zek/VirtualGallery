using VG.MasterpieceCatalog.Domain;
using VG.MasterpieceCatalog.Domain.BaseTypes;

namespace VG.MasterpieceCatalog.Contract
{
  public class MasterpieceReservedEvent 
  {
    public MasterpieceId Id { get; }
    public CustomerId CustomerId { get; }
    public int Version { get; }

    public MasterpieceReservedEvent(MasterpieceId id, CustomerId customerId, int version)
    {
      Id = id;
      CustomerId = customerId;
      Version = version;
    }
  }
}