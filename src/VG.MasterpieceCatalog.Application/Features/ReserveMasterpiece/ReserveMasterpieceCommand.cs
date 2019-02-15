using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Application.Features.ReserveMasterpiece
{
  public class ReserveMasterpieceCommand
  {
    public MasterpieceId MasterpieceId { get; set; }
    public CustomerId CustomerId { get; }
    public int? ExpectedVersion { get; }

    public ReserveMasterpieceCommand(MasterpieceId masterpieceId, CustomerId customerId, int? expectedVersion)
    {
      MasterpieceId = masterpieceId;
      CustomerId = customerId;
      ExpectedVersion = expectedVersion;
    }
  }
}