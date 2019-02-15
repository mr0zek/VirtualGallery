using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Application.Features.RevokeMasterpieceReservation
{
  public class RevokeMasterpieceReservationCommand
  {
    public MasterpieceId MasterpieceId { get; set; }
    public CustomerId CustomerId { get; set; }
    public int? ExpectedVersion { get; }

    public RevokeMasterpieceReservationCommand(MasterpieceId masterpieceId, CustomerId customerId, int? expectedVersion)
    {
      MasterpieceId = masterpieceId;
      CustomerId = customerId;
      ExpectedVersion = expectedVersion;
    }

    
  }
}