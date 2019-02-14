using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Application.Features.RevokeMasterpieceReservation
{
  public class RevokeMasterpieceReservationCommand
  {
    public RevokeMasterpieceReservationCommand(MasterpieceId masterpieceId, CustomerId customerId)
    {
      MasterpieceId = masterpieceId;
      CustomerId = customerId;
    }

    public MasterpieceId MasterpieceId { get; set; }
    public CustomerId CustomerId { get; set; }
  }
}