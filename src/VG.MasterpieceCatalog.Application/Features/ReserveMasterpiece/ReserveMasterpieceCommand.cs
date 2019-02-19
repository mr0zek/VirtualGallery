using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Application.Features.ReserveMasterpiece
{
  public class ReserveMasterpieceCommand
  {
    public MasterpieceId MasterpieceId { get; set; }
    public CustomerId CustomerId { get; }

    public ReserveMasterpieceCommand(MasterpieceId masterpieceId, CustomerId customerId)
    {
      MasterpieceId = masterpieceId;
      CustomerId = customerId;
    }
  }
}